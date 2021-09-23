namespace OfiCondo.Management.Support.ApiKeyAuthentication.Features.Authentication
{
    using System;
    using System.Collections.Generic;
    public class ApiKey
    {
        public ApiKey(string app, string key, IReadOnlyCollection<string> roles)
        {
            App = app ?? throw new ArgumentNullException(nameof(app));
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Roles = roles ?? throw new ArgumentNullException(nameof(roles));
        }

        public string App { get; }
        public string Key { get; }
        public IReadOnlyCollection<string> Roles { get; }
    }
}
