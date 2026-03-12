---
paths:
  - "src/Core/ModuleTech.Core.Base/Middlewares/**"
  - "src/Core/ModuleTech.Core.ExceptionHandling/Middlewares/**"
  - "src/Core/ModuleTech.Core.Networking/Http/Infrastructure/**"
---

# Middleware Kurallari

- ASP.NET Core middleware convention'a uy: `InvokeAsync(HttpContext context)` metodu kullan
- `RequestDelegate _next` field'i constructor'da inject edilmeli
- Async middleware'larda try-catch ZORUNLU
- Exception middleware'da `context.Response.StatusCode` ve `context.Response.WriteAsJsonAsync` kullan
- Uretimde stack trace GOSTERME (response body'e exception detayi koyma)
- `IMiddleware` interface veya convention-based middleware kullan
- Middleware sirasi onemli (Program.cs): UseExceptionHandling → UseAuthentication → UseAuthorization → UseHeaderContext → MapControllers
- Middleware registration icin extension method yaz (ornek: `app.UseExceptionHandling()`)
