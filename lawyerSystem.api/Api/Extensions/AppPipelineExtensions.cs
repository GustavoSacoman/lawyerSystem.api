namespace lawyerSystem.api.Api.Extensions;

public static class AppPipelineExtensions
{
    public static void UseApiPipeline(
        this WebApplication app,
        IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("AllowAll");
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
    }
}
