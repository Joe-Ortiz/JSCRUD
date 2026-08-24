
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JSCRUD.Models;
using JSCRUD.Data;

public class ProductsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: PRODUCTS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Product.ToListAsync());
    }

    // GET: PRODUCTS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _context.Product
            .FirstOrDefaultAsync(m => m.ProductId == id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // GET: PRODUCTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PRODUCTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ProductId,Name,Price")] Product product)
    {
        if (ModelState.IsValid)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    // GET: PRODUCTS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _context.Product.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    // POST: PRODUCTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("ProductId,Name,Price")] Product product)
    {
        if (id != product.ProductId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    // GET: PRODUCTS/GetProduct/5
    [HttpGet]
    public async Task<IActionResult> GetProduct(int? id)
    {
        if (id == null)
        {
            return BadRequest();
        }

        var product = await _context.Product.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        return Ok(ToProductPayload(product));
    }

    // POST: PRODUCTS/CreateFromIndex
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateFromIndex([Bind("Name,Price")] Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Product.Add(product);
        await _context.SaveChangesAsync();

        return Ok(ToProductPayload(product));
    }

    // POST: PRODUCTS/EditFromIndex/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditFromIndex(int? id, [Bind("ProductId,Name,Price")] Product product)
    {
        if (id == null || id != product.ProductId)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingProduct = await _context.Product.FindAsync(id);
        if (existingProduct == null)
        {
            return NotFound();
        }

        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;

        await _context.SaveChangesAsync();

        return Ok(ToProductPayload(existingProduct));
    }

    // POST: PRODUCTS/DeleteFromIndex
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteFromIndex(int? id)
    {
        if (id == null)
        {
            return BadRequest();
        }

        var product = await _context.Product.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _context.Product.Remove(product);
        await _context.SaveChangesAsync();

        return Ok();
    }

    private static object ToProductPayload(Product product)
    {
        return new
        {
            productId = product.ProductId,
            name = product.Name,
            price = product.Price,
            priceDisplay = product.Price.ToString("C")
        };
    }

    private bool ProductExists(int? productid)
    {
        return _context.Product.Any(e => e.ProductId == productid);
    }
}
