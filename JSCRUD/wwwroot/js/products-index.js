document.addEventListener('DOMContentLoaded', function () {
    var productsTable = document.getElementById('productsTable');
    var productsTableBody = document.getElementById('productsTableBody');
    var antiForgeryToken = document.querySelector('#antiForgeryForm input[name="__RequestVerificationToken"]').value;

    var productFormModal = new bootstrap.Modal(document.getElementById('productFormModal'));
    var detailsModal = new bootstrap.Modal(document.getElementById('detailsModal'));
    var deleteConfirmModal = new bootstrap.Modal(document.getElementById('deleteConfirmModal'));

    var openCreateModalButton = document.getElementById('openCreateModalButton');
    var saveProductButton = document.getElementById('saveProductButton');
    var confirmDeleteButton = document.getElementById('confirmDeleteButton');

    var productFormModalLabel = document.getElementById('productFormModalLabel');
    var formProductId = document.getElementById('formProductId');
    var formProductName = document.getElementById('formProductName');
    var formProductPrice = document.getElementById('formProductPrice');
    var productFormError = document.getElementById('productFormError');

    var detailsProductName = document.getElementById('detailsProductName');
    var detailsProductPrice = document.getElementById('detailsProductPrice');

    var modalProductName = document.getElementById('modalProductName');
    var modalProductPrice = document.getElementById('modalProductPrice');

    var selectedProductId = null;
    var selectedRow = null;

    function setFormError(message) {
        if (!message) {
            productFormError.classList.add('d-none');
            productFormError.textContent = '';
            return;
        }

        productFormError.classList.remove('d-none');
        productFormError.textContent = message;
    }

    function toRequestBody(payload) {
        var body = new URLSearchParams();
        Object.keys(payload).forEach(function (key) {
            body.append(key, payload[key]);
        });
        body.append('__RequestVerificationToken', antiForgeryToken);
        return body.toString();
    }

    function upsertRow(product) {
        var existingRow = document.getElementById('product-row-' + product.productId);
        var row = existingRow || document.createElement('tr');

        row.id = 'product-row-' + product.productId;
        row.innerHTML = '<td class="product-name"></td>' +
            '<td class="product-price"></td>' +
            '<td>' +
            '<a href="#" class="edit-link" data-product-id="' + product.productId + '">Edit</a> | ' +
            '<a href="#" class="details-link" data-product-id="' + product.productId + '">Details</a> | ' +
            '<a href="#" class="delete-link" data-product-id="' + product.productId + '">Delete</a>' +
            '</td>';

        row.querySelector('.product-name').textContent = product.name;
        row.querySelector('.product-price').textContent = product.priceDisplay;

        if (!existingRow) {
            productsTableBody.appendChild(row);
        }
    }

    function loadProduct(id) {
        var getUrl = productsTable.dataset.getUrl + '?id=' + encodeURIComponent(id);

        return fetch(getUrl)
            .then(function (response) {
                if (!response.ok) {
                    throw new Error('Unable to load product.');
                }

                return response.json();
            });
    }

    openCreateModalButton.addEventListener('click', function () {
        saveProductButton.dataset.mode = 'create';
        productFormModalLabel.textContent = 'Create Product';
        saveProductButton.textContent = 'Create';
        formProductId.value = '';
        formProductName.value = '';
        formProductPrice.value = '';
        setFormError('');
        productFormModal.show();
    });

    saveProductButton.addEventListener('click', function () {
        var mode = this.dataset.mode;
        var name = formProductName.value.trim();
        var price = formProductPrice.value;

        if (!name || price === '') {
            setFormError('Name and price are required.');
            return;
        }

        var postUrl = mode === 'edit'
            ? this.dataset.editUrl + '?id=' + encodeURIComponent(formProductId.value)
            : this.dataset.createUrl;

        var payload = mode === 'edit'
            ? { ProductId: formProductId.value, Name: name, Price: price }
            : { Name: name, Price: price };

        fetch(postUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
            },
            body: toRequestBody(payload)
        })
            .then(function (response) {
                if (!response.ok) {
                    throw new Error('Save failed.');
                }

                return response.json();
            })
            .then(function (product) {
                upsertRow(product);
                productFormModal.hide();
                setFormError('');
            })
            .catch(function () {
                setFormError('Unable to save product right now. Please try again later.');
            });
    });

    productsTableBody.addEventListener('click', function (event) {
        var editLink = event.target.closest('.edit-link');
        if (editLink) {
            event.preventDefault();
            loadProduct(editLink.dataset.productId)
                .then(function (product) {
                    saveProductButton.dataset.mode = 'edit';
                    productFormModalLabel.textContent = 'Edit Product';
                    saveProductButton.textContent = 'Save';
                    formProductId.value = product.productId;
                    formProductName.value = product.name;
                    formProductPrice.value = product.price;
                    setFormError('');
                    productFormModal.show();
                })
                .catch(function () {
                    alert('Unable to load product right now. Please try again later.');
                });
            return;
        }

        var detailsLink = event.target.closest('.details-link');
        if (detailsLink) {
            event.preventDefault();
            loadProduct(detailsLink.dataset.productId)
                .then(function (product) {
                    detailsProductName.textContent = product.name;
                    detailsProductPrice.textContent = product.priceDisplay;
                    detailsModal.show();
                })
                .catch(function () {
                    alert('Unable to load product details right now. Please try again later.');
                });
            return;
        }

        var deleteLink = event.target.closest('.delete-link');
        if (deleteLink) {
            event.preventDefault();
            selectedProductId = deleteLink.dataset.productId;
            selectedRow = deleteLink.closest('tr');
            modalProductName.textContent = selectedRow.querySelector('.product-name').textContent;
            modalProductPrice.textContent = selectedRow.querySelector('.product-price').textContent;
            deleteConfirmModal.show();
        }
    });

    confirmDeleteButton.addEventListener('click', function () {
        if (!selectedProductId) {
            return;
        }

        fetch(this.dataset.deleteUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
            },
            body: toRequestBody({ id: selectedProductId })
        })
            .then(function (response) {
                if (!response.ok) {
                    throw new Error('Delete failed.');
                }

                if (selectedRow) {
                    selectedRow.remove();
                }

                deleteConfirmModal.hide();
                selectedProductId = null;
                selectedRow = null;
            })
            .catch(function () {
                alert('Unable to delete this product right now. Please try again later.');
            });
    });
});
