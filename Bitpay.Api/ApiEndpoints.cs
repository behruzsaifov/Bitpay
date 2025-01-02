namespace Bitpay.Api;

public static class ApiEndpoints
{
    public const string ApiBase = "/api";

    public static class Payments
    {
        public const string Base = $"{ApiBase}/payments";
        public const string Create = Base;
        public const string Get = $"{Base}/{{id:guid}}";
        public const string GetAll = Base;
        public const string Cancel = $"{Base}/{{id:guid}}";
    }
}