namespace ValidHabit.WebUI.Middlewares
{
    public class RequireAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public RequireAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context is null || context.User.Identity is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (!context.User.Identity.IsAuthenticated)
            {
                var allowedPaths = new List<string>
                {
                    "/Home/Index",
                    "/Account/Login",
                    "/Account/Register",
                    "/Account/EmailConfirmation",
                    "/Account/ResendConfirmationEmail",
                    "/Account/ConfirmEmail",
                    "/Account/EmailConfirmed"
                };

                if (!allowedPaths.Contains(context.Request.Path.Value, StringComparer.OrdinalIgnoreCase))
                {
                    context.Response.Redirect("/Account/Login");
                }
            }

            await _next(context);
        }
    }

}
