namespace OfiCondo.Management.Support.ApiKeyAuthentication.Model
{
    using System.Collections.Generic;
    public class SecurityKeys
    {
        public List<KeyInfo> ApplicationKeys { get; set; }
    }

    public class KeyInfo
    {
        public string App { get; set; }
        public string Key { get; set; }
        public List<string> Roles { get; set; }
    }
}
