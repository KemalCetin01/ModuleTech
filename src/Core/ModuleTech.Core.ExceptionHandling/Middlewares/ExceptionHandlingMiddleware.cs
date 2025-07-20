using ModuleTech.Core.ExceptionHandling.Exceptions.Common;
using ModuleTech.Core.ExceptionHandling.Models;
using ModuleTech.Core.ExceptionHandling.Wrapper;
using Serilog;
using System.Text.Json.Serialization;

namespace ModuleTech.Core.ExceptionHandling.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private static readonly Serilog.ILogger Logger = Log.ForContext<ExceptionHandlingMiddleware>();
    private readonly bool _isDetailedErrorEnable;

    public ExceptionHandlingMiddleware(RequestDelegate next,bool isDetailedErrorEnable)
    {
        _next = next;
        _isDetailedErrorEnable = isDetailedErrorEnable;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            var errParam = new BaseExceptionLogParamModel();
            var response = context.Response;
            response.ContentType = "application/json";
            var responseModel = new ExceptionResponse();

            if (exception is BaseException e)
            {
                response.StatusCode = (int) e.ResultCode;
                response.HttpContext.Response.StatusCode = (int) e.ResultCode;
                responseModel.Message = e.Message;
                responseModel.Errors = e.Errors;
                responseModel.StatusCode = e.StatusCode;
                errParam.Errors = e.Errors;
                errParam.StatusCode = e.StatusCode;
            }
            else
            {
                response.StatusCode = (int)Constants.Constants.DefaultStatusCode;
                response.HttpContext.Response.StatusCode = (int)Constants.Constants.DefaultStatusCode;
                responseModel.Message = Constants.Constants.DefaultErrorMessage;
                responseModel.StatusCode = Constants.Constants.DefaultExceptionStatusCode;
                errParam.StatusCode = Constants.Constants.DefaultExceptionStatusCode;
            }

            if (_isDetailedErrorEnable)
                responseModel.Trace = new ExceptionDetailedResponse
                    {StackTrace = exception.StackTrace, Message = exception.Message};

            Logger.Error(exception, exception.Message + " {@errParam}", errParam);

            Logger.ForContext(",", "");

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            var result = JsonSerializer.Serialize(responseModel, serializeOptions);

            await response.WriteAsync(result);
        }
    }
}