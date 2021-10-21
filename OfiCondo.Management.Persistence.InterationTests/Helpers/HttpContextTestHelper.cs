namespace OfiCondo.Management.Persistence.InterationTests.Helpers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class HttpContextTestHelper
    {
        public static ControllerContext GetContext()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["Authorization"] = $"Bearer {Jwt}";

            return new ControllerContext()
            {
                HttpContext = httpContext
            };
        }

        public const string Jwt = @"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NisImtpZCI6Ilg1ZVhrNHh5b2pORnVtMWtsMll0djhkbE5QNC1jNTdkTzZRR1RWQndhTmsifQ.eyJleHAiOjE2Mjg4MDY2MjUsIm5iZiI6MTYyODgwNTcyNSwidmVyIjoiMS4wIiwiaXNzIjoiaHR0cHM6Ly9hZHJpYW4wMTMuYjJjbG9naW4uY29tLzM3YzMwYWY4LWY3ZjctNDMxNS04MWUwLThhZjExZDg4Yzg0MS92Mi4wLyIsInN1YiI6ImRkMWU2NjFiLTdjMWItNDdmMy1iZDU5LTczZGNlNDI3M2Y1NiIsImF1ZCI6ImYzN2NmZWJhLWY2ZWMtNGFmNC1hYjVmLTg4ZWU5YWVmNjgzOSIsIm5vbmNlIjoiNTg4MDM2NTctYzk5MC00MTJiLWIzYzItOTQ3ZTNhYWMyNzJlIiwiaWF0IjoxNjI4ODA1NzI1LCJhdXRoX3RpbWUiOjE2Mjg4MDU3MjQsIm9pZCI6ImRkMWU2NjFiLTdjMWItNDdmMy1iZDU5LTczZGNlNDI3M2Y1NiIsImpvYlRpdGxlIjoiMyIsImVtYWlscyI6WyJhZHJpYW4wMTNAZ21haWwuY29tIl0sInRmcCI6IkIyQ18xX0p1c3RTaWduSW4ifQ.XSTjEl4zKJ4_-fADDp4KrZwT-2J3nrEj79q6sr6TLHsqS8cPa5HYroXnJZfl2AjlBBgzAeV81D-jAXoPmdopZ1SmUGVBTQcjNB4CQQdYLSNQfG_byugkjEvE3Re8Q5L1-IMtR1rpLMl86-liv8jTLQiYhIw45pvutj_sdNvKPwF6sC3TdTe5lIwrCn-H9kumihtyZ_grqfjBuoEBpU2X9O7BMRNUs2CjLTE9TonsFZ4c1BOEPEQgCezWooGkSepBff2ReftJyrHpUT9SyDtYQ9CYz3NafROVBUz8tTMQ5TQW_M-gEbRamwU17tvU5f88NhrOUBLS5Qr--PEzZ9TqSw";
    }
}
