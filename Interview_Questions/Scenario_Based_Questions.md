# Scenario-Based .Net Core C# Web API Interview Questions

1. **Scenario: Your application is receiving a JSON payload from a client application and you need to ensure the data received matches a specific schema. How would you implement this in .Net Core Web API?**
   In .Net Core Web API, you can use model validation to ensure the incoming data matches a certain schema. You would define a model class with the required properties and data annotations for validation. Then, in your API action method, you would check the `ModelState.IsValid` property to verify if the data is valid.

2. **Scenario: You are designing a RESTful API for a library. The API needs to allow clients to get a list of books, get details about a book, add a new book, update a book's details, and delete a book. How would you design this API?**
   You would create a `BooksController` with the following methods:
   - `GetBooks()`: GET /api/books
   - `GetBook(int id)`: GET /api/books/{id}
   - `AddBook(Book book)`: POST /api/books
   - `UpdateBook(int id, Book book)`: PUT /api/books/{id}
   - `DeleteBook(int id)`: DELETE /api/books/{id}

3. **Scenario: You need to add authentication to your .Net Core Web API. The API is consumed by a variety of clients, including web and mobile apps. What approach would you take?**
   For this scenario, you could use JWT (JSON Web Token) authentication. This type of authentication is ideal for APIs consumed by various clients as it's based on tokens, not cookies. You would use the ASP.NET Core JWT Bearer Authentication package to implement this.

4. **Scenario: Your .Net Core Web API is expected to receive high traffic. What strategies would you use to ensure it can handle the load?**
   Some strategies include:
   - Implementing caching to reduce the load on the server and improve response times.
   - Using asynchronous programming to improve the scalability of the API.
   - Implementing rate limiting to prevent any single client from overloading the server.
   - If possible, deploying the API on multiple servers (load balancing).

5. **Scenario: You are creating a RESTful Web API and want to adhere to HATEOAS principles. How would you do this in .Net Core Web API?**
   To adhere to HATEOAS, your API should return not just the requested data, but also related links. In .Net Core Web API, you can do this by including a `Links` property in your response models that contains a list of links. Each link would be an object with properties for `Href`, `Rel`, and `Method`, representing the URL, relationship, and HTTP method respectively.

1. **Scenario**: You are building a RESTful Web API using .NET Core that allows clients to manage a list of products. The product information includes an ID, name, description, and price. How would you design the API endpoints?

   **Answer**: You would typically design the endpoints around the product resource, using the standard HTTP verbs to represent actions on that resource. Here are some examples:

   - `GET /api/products`: Retrieve a list of all products.
   - `GET /api/products/{id}`: Retrieve the details of a single product specified by its ID.
   - `POST /api/products`: Create a new product. The product data would be sent in the request body in JSON format.
   - `PUT /api/products/{id}`: Update an existing product specified by its ID. The updated product data would be sent in the request body in JSON format.
   - `DELETE /api/products/{id}`: Delete an existing product specified by its ID.

2. **Scenario**: You want to implement versioning in your .NET Core Web API to avoid breaking changes for clients using an older version of the API. How would you accomplish this?

   **Answer**: There are several strategies you can use to version your API in .NET Core:

   - **URL path versioning**: Include the API version in the URL path (e.g., `/api/v1/products`).
   - **Query string versioning**: Include the API version as a query parameter (e.g., `/api/products?version=1`).
   - **Header versioning**: Include the API version in a custom HTTP header.
   - **Media type versioning (or "content negotiation")**: Include the API version in the `Accept` header.

   Each approach has its pros and cons, and the right choice depends on your specific requirements. In any case, you should aim to make your API as backward-compatible as possible to minimize the impact of changes on clients.

3. **Scenario**: You have a scenario where you need to allow cross-origin requests to your .NET Core Web API. How would you enable CORS in your Web API?

   **Answer**: CORS (Cross-Origin Resource Sharing) can be enabled in a .NET Core Web API by adding the CORS middleware to the request pipeline in the `Startup.cs` file. Here is a basic example:

   ```csharp
   public void ConfigureServices(IServiceCollection services)
   {
       services.AddCors(options =>
       {
           options.AddPolicy("AllowSpecificOrigin",
               builder => builder.WithOrigins("http://example.com"));
       });

       services.AddControllers();
   }

   public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
   {
       app.UseCors("AllowSpecificOrigin");

       app.UseRouting();

       app.UseEndpoints(endpoints =>
       {
           endpoints.MapControllers();
       });
   }
   ```

   This example adds a CORS policy that allows requests from the origin `http://example.com`. You can adjust the policy to meet your requirements, for example by allowing specific HTTP methods or headers.

4. **Scenario**: You are developing a .NET Core Web API and you want to ensure that sensitive data like connection strings are not included in the source code. How would you handle this?

   **Answer**: You can use the Secret Manager tool in .NET Core to store sensitive data during the development of your Web API. The Secret Manager tool stores sensitive data in a separate `secrets.json` file that is not included in the project folder, so it won't be accidentally committed to a source control system.

   Here is how you can use the Secret Manager tool:

   - Enable the Secret Manager tool for your project by running the following command in the command line: `dotnet user-secrets init`
   - Set a secret by running `dotnet user-secrets set "ConnectionStrings:Default" "your_connection_string"`
   - In your code, you can access the secret using the `IConfiguration` service:

   ```csharp
   var connectionString = Configuration.GetConnectionString("Default");
   ```

   Note that the Secret Manager tool is intended for development purposes only. For production scenarios, you should consider more secure methods of storing sensitive data, such as Azure Key Vault or environment variables.

5. **Scenario**: You are creating a .NET Core Web API and you want to return different types of responses from your action methods, such as a 200 OK response with data for a successful operation or a 400 Bad Request response for an error. How would you accomplish this?

   **Answer**: The `IActionResult` return type in .NET Core allows you to return different types of responses from your action methods. You can use the various helper methods provided by the `ControllerBase` class to return different HTTP status codes. Here is an example:

   ```csharp
   [HttpGet("{id}")]
   public IActionResult GetProduct(int id)
   {
       var product = _productService.GetProduct(id);

       if (product == null)
       {
           return NotFound();
       }

       return Ok(product);
   }
   ```

   In this example, if the product is not found, the method returns a 404 Not Found response using the `NotFound` helper method. If the product is found, the method returns a 200 OK response with the product data in the response body using the `Ok` helper method.

1. **Question: How would you design a RESTful Web API endpoint to allow a client to read a specific order's details from an e-commerce site?**

    **Answer:** 
    In a RESTful Web API, resources are identified by URLs. An order in an e-commerce site can be considered as a resource. To allow a client to read a specific order's details, we can design an endpoint like `GET /api/orders/{orderId}`. Here, `orderId` is a placeholder for the ID of the order. 

    For example, to get the details of the order with ID 123, the client can send a GET request to `/api/orders/123`.

    In terms of C# code, the endpoint can be implemented in a controller like this:

    ```csharp
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var order = await _context.Orders.FindAsync(id);

        if (order == null)
        {
            return NotFound();
        }

        return order;
    }
    ```
    This code uses the `[HttpGet]` attribute to specify that this action should handle GET requests. The `{id}` in the route template is a placeholder for the order's ID. The `FindAsync` method is used to retrieve the order from the database asynchronously.


2. **Question: How would you handle versioning in a RESTful Web API?**

    **Answer:** 
    There are several ways to handle versioning in a RESTful Web API. Here are three common methods:

    - **URL path versioning:** In this method, the API version is included in the URL. For example, `api/v1/orders` for version 1 and `api/v2/orders` for version 2.
    - **Query string versioning:** The API version is included in the query string. For example, `api/orders?version=1`.
    - **Header versioning:** The API version is included in a custom HTTP header. For example, `api-version: 1`.

    In .NET Core, you can use the `Microsoft.AspNetCore.Mvc.Versioning` package to handle API versioning. This package supports all the above methods of versioning.

    Here is an example of how to enable URL path versioning in .NET Core:

    ```csharp
    services.AddApiVersioning(o => 
    {
        o.DefaultApiVersion = new ApiVersion(1, 0);
        o.AssumeDefaultVersionWhenUnspecified = true;
        o.ReportApiVersions = true;
        o.ApiVersionReader = new UrlSegmentApiVersionReader();
    });
    ```

    In this example, the default API version is set to 1.0. If the client does not specify an API version, the default version will be used. The `UrlSegmentApiVersionReader` class is used to read the API version from the URL path.


3. **Question: How would you implement caching in a RESTful Web API to improve performance?**

    **Answer:** 
    Caching can significantly improve the performance of a RESTful Web API by reducing the load on the server and decreasing the client's network latency. In HTTP, caching is typically implemented using cache-related headers, such as `Cache-Control`, `ETag`, and `Last-Modified`.

    In .NET Core, you can use the `ResponseCache` attribute to control the caching behavior of an action method. Here is an example:

    ```csharp
    [HttpGet]
    [ResponseCache(Duration = 60)]
    public IEnumerable<Product> GetProducts()
    {
        return _productService.GetAll();
    }
    ```

    In this example, the `ResponseCache` attribute is used to specify that the response of the `GetProducts` method should be cached for 60 seconds. The client will store the response in its local cache and reuse it for subsequent requests made within the next 60 seconds. 

    For more advanced caching scenarios, such as conditional caching based on `ETag` or `Last-Modified`, you would need to write custom middleware or use a third-party library.


1. **Question: You are building a RESTful Web API for a blogging platform. It has resources for blog posts and comments. How would you design the API endpoints for creating a new comment on a blog post?**

    **Answer:** 
    In a RESTful Web API, the relationship between resources can be represented in the URL. In this case, a comment is related to a blog post. Therefore, you can design an endpoint like `POST /api/posts/{postId}/comments` to create a new comment on a blog post. Here, `postId` is a placeholder for the ID of the blog post.

    In terms of C# code, the endpoint can be implemented in a controller like this:

    ```csharp
    [HttpPost("{postId}/comments")]
    public async Task<ActionResult<Comment>> CreateComment(int postId, Comment comment)
    {
        var post = await _context.Posts.FindAsync(postId);
        if (post == null)
        {
            return NotFound();
        }

        comment.PostId = postId;
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
    }
    ```
    This code first checks if the blog post exists. If not, it returns a 404 Not Found status. Then it sets the `PostId` of the comment, adds the comment to the database, and saves the changes. Finally, it returns a 201 Created status with a `Location` header pointing to the new comment.

2. **Question: How would you handle exceptions globally in a .NET Core Web API?**

    **Answer:** 
    In a .NET Core Web API, you can handle exceptions globally using middleware. The middleware catches any unhandled exceptions that occur in the request processing pipeline and returns an appropriate HTTP response.

    Here is an example of a simple exception handling middleware:

    ```csharp
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("An unexpected error occurred.");
            }
        }
    }
    ```
    This middleware catches any exceptions, sets the response status code to 500 Internal Server Error, and writes an error message to the response.

    You can add this middleware to the pipeline in the `Configure` method of the `Startup` class like this:

    ```csharp
    public void Configure(IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        // other middleware...
    }
    ```

3. **Question: How would you implement rate limiting in a .NET Core Web API to prevent abuse?**

    **Answer:** 
    Rate limiting is a technique for limiting network traffic. It sets a limit on how many requests a client can make to the API within a certain time period.

    In .NET Core, you can implement rate limiting using middleware. There are several third-party libraries available, such as `AspNetCoreRateLimit`.

    Here is an example of how to set up IP rate limiting with `AspNetCoreRateLimit`:

    ```csharp
    services.AddOptions();
    services.AddMemoryCache();
    services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));
    services.Configure<IpRateLimitPolicies>(Configuration.GetSection("IpRateLimitPolicies"));
    services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
    services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
    services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
    ```

    In this example, the rate limiting options and policies are loaded from the configuration (appsettings.json). The `MemoryCacheIpPolicyStore` and `MemoryCacheRateLimitCounterStore` are used to store the IP policies and rate limit counters in memory.

    You can then add the rate limiting middleware to the pipeline:

    ```csharp
    public void Configure(IApplicationBuilder app)
    {
        app.UseIpRateLimiting();
        // other middleware...
    }
    ```

1. **Question: You are building a RESTful Web API for a library. The library has resources for books and authors. An author can have multiple books. How would you design the API endpoints for getting all books of a specific author?**

    **Answer:** 
    In a RESTful Web API, the relationship between resources can be represented in the URL. In this case, a book is related to an author. Therefore, you can design an endpoint like `GET /api/authors/{authorId}/books` to get all books of a specific author. Here, `authorId` is a placeholder for the ID of the author.

    In terms of C# code, the endpoint can be implemented in a controller like this:

    ```csharp
    [HttpGet("{authorId}/books")]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooksByAuthor(int authorId)
    {
        var author = await _context.Authors.FindAsync(authorId);
        if (author == null)
        {
            return NotFound();
        }

        var books = await _context.Books
            .Where(b => b.AuthorId == authorId)
            .ToListAsync();

        return books;
    }
    ```
    This code first checks if the author exists. If not, it returns a 404 Not Found status. Then it retrieves the books of the author from the database and returns them.

2. **Question: How would you implement authentication and authorization in a .NET Core Web API?**

    **Answer:** 
    Authentication and authorization are critical components of most web APIs. 

    In .NET Core, you can use the built-in Identity system for authentication. This involves configuring the Identity services in `Startup.cs`, creating an account controller that handles registration and login, and applying the `[Authorize]` attribute to actions that require authentication.

    For example, to register a new user, you can create a `Register` action in the account controller like this:

    ```csharp
    [HttpPost("register")]
    public async Task<ActionResult> Register(RegisterDto dto)
    {
        var user = new IdentityUser { UserName = dto.Email, Email = dto.Email };
        var result = await _userManager.CreateAsync(user, dto.Password);

        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest(result.Errors);
    }
    ```
    This code creates a new IdentityUser and uses the `UserManager` service to create a new user account with the specified password.

    For authorization, you can use policy-based authorization. This involves defining policies based on requirements and applying these policies using the `[Authorize(Policy = "PolicyName")]` attribute.

    For example, to define a policy that requires users to have the "Admin" role, you can add this code to `Startup.cs`:

    ```csharp
    services.AddAuthorization(options =>
    {
        options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
    });
    ```
    You can then apply this policy to an action like this:

    ```csharp
    [HttpGet("admin")]
    [Authorize(Policy = "RequireAdminRole")]
    public IActionResult AdminOnly()
    {
        return Ok("Hello, Admin!");
    }
    ```

3. **Question: How would you handle file uploads in a .NET Core Web API?**

    **Answer:** 
    File uploads in a .NET Core Web API can be handled using the `IFormFile` interface. You can create an action that accepts a `IFormFile` parameter, and then save the file to disk or a blob storage.

    Here is an example of how to handle file uploads:

    ```csharp
    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        var filePath = Path.GetTempFileName();

        using (var stream = System.IO.File.Create(filePath))
        {
            await file.CopyToAsync(stream);
        }

        return Ok();
    }
    ```
    This code creates a temporary file and copies the contents of the uploaded file to this temporary file. In a real application, you would probably want to save the file to a more permanent location or a blob storage, and store the file information in a database.

1. **Question: You are building a .NET 6 Web API for a news portal. The API has a high traffic volume, and you want to log the time taken to process each request. How would you design a middleware to achieve this?**

    **Answer:**
    In .NET 6, you can create a custom middleware to measure and log the time taken to process each request. The middleware can start a stopwatch before calling `_next(context)`, and stop the stopwatch after `_next(context)` returns. The elapsed time is then the time taken to process the request.

    Here is an example of how you might implement this middleware:

    ```csharp
    public class TimingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TimingMiddleware> _logger;

        public TimingMiddleware(RequestDelegate next, ILogger<TimingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            await _next(context);
            stopwatch.Stop();

            _logger.LogInformation("Request to {Path} took {ElapsedMilliseconds}ms", 
                context.Request.Path, stopwatch.ElapsedMilliseconds);
        }
    }
    ```

    This middleware logs the time taken to process each request, along with the request path. You can add this middleware to the pipeline in the `Configure` method of the `Program` class like this:

    ```csharp
    var app = builder.Build();

    app.UseMiddleware<TimingMiddleware>();
    // other middleware...

    app.Run();
    ```

2. **Question: How would you implement a middleware in .NET 6 Web API to handle and return custom error responses for exceptions thrown in the application?**

    **Answer:**
    In .NET 6, you can create a custom exception handling middleware to catch any unhandled exceptions and return a custom error response. 

    Here is an example of how you might implement this middleware:

    ```csharp
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception has occurred while executing the request.");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new { Message = "An error occurred. Please try again later." });
            }
        }
    }
    ```

    This middleware catches any exceptions, logs the exception, sets the response status code to 500, and writes a custom error message to the response. You can add this middleware to the pipeline in the `Configure` method of the `Program` class like this:

    ```csharp
    var app = builder.Build();

    app.UseMiddleware<ExceptionHandlingMiddleware>();
    // other middleware...

    app.Run();
    ```

3. **Question: How would you implement a middleware in .NET 6 Web API to check an API key in the request header, and reject requests with an invalid or missing API key?**

    **Answer:**
    In .NET 6, you can create a custom middleware to check for an API key in the request header. The middleware can read the API key from the request header, compare it with the expected API key, and either call `_next(context)` to continue processing the request or return a 401 Unauthorized response.

    Here is an example of how you might implement this middleware:

    ```csharp
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string ApiKeyHeaderName = "X-API-KEY";
        private const string ExpectedApiKey = "YourExpectedApiKey";

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var receivedApiKey) ||
                receivedApiKey != ExpectedApiKey)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new { Message = "Invalid API key." });
                return;
            }

            await _next(context);
        }
    }
    ```

    This middleware checks if the `X-API-KEY` header is present and if it matches the expected API key. If not, it returns a 401 Unauthorized response. Otherwise, it continues processing the request. You can add this middleware to the pipeline in the `Configure` method of the `Program` class like this:

    ```csharp
    var app = builder.Build();

    app.UseMiddleware<ApiKeyMiddleware>();
    // other middleware...

    app.Run();
    ```

