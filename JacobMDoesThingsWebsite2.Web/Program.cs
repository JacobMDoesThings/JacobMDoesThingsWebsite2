var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

//Configuration from the Compositionroot.
builder.Services.ConfigureServices(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
if (app.Environment.IsDevelopment())
{
    IdentityModelEventSource.ShowPII = true;
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapBlazorHub();

//redirect after signout otherwise will be directed to signedout identity page.
app.UseRewriter(
    new RewriteOptions().Add(
        context =>
        {
            if (context.HttpContext.Request.Path == "/MicrosoftIdentity/Account/SignedOut")
            { context.HttpContext.Response.Redirect("/"); }
        })
);


//For Identity and Controllers
app.MapControllers();
app.MapRazorPages();
app.MapFallbackToPage("/_Host");
app.Run();
