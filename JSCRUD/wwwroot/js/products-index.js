document.addEventListener('DOMContentLoaded', function () {
    var modalElement = document.getElementById('deleteConfirmModal');
    var deleteConfirmModal = new bootstrap.Modal(modalElement);
    var modalProductName = document.getElementById('modalProductName');
    var modalProductPrice = document.getElementById('modalProductPrice');
    var confirmDeleteButton = document.getElementById('confirmDeleteButton');
    var deleteLinks = document.querySelectorAll('.delete-link');
    var antiForgeryToken = document.querySelector('#deleteAntiForgeryForm input[name="__RequestVerificationToken"]').value;
    var selectedProductId = null;
    var selectedRow = null;

    deleteLinks.forEach(function (link) {
        link.addEventListener('click', function (event) {
            event.preventDefault();

            selectedProductId = this.dataset.productId;
            selectedRow = this.closest('tr');
            modalProductName.textContent = this.dataset.productName;
            modalProductPrice.textContent = this.dataset.productPrice;

            deleteConfirmModal.show();
        });
    });

    confirmDeleteButton.addEventListener('click', function () {
        if (!selectedProductId) {
            return;
        }

        var deleteUrl = this.dataset.deleteUrl;
        var body = new URLSearchParams();
        body.append('id', selectedProductId);
        body.append('__RequestVerificationToken', antiForgeryToken);

        fetch(deleteUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
            },
            body: body.toString()
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
