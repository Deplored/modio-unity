﻿
namespace ModIO.Implementation.API.Requests
{
    static class AddMod
    {
        public static WebRequestConfig Request(ModProfileDetails details)
        {
            var request = new WebRequestConfig()
            {
                Url = $"{Settings.server.serverURL}{@"/games/"}{Settings.server.gameId}{@"/mods"}?",
                RequestMethodType = "POST",
                ShouldRequestTimeout = false,
            };

            
            
            request.AddField("visible", details.visible == false ? "0" : "1");
            request.AddField("name", details.name);
            request.AddField("summary", details.summary);
            request.AddField("description", details.description);
            request.AddField("name_id", details.name_id);
            request.AddField("homepage_url", details.homepage_url);
            request.AddField("stock", details.maxSubscribers.ToString());
            request.AddField("metadata_blob", details.metadata);

            if(details.contentWarning != null)
                request.AddField("maturity_option", ((int)details.contentWarning).ToString());

            if(details.communityOptions != null)
                request.AddField("community_options", ((int)details.communityOptions).ToString());

            if(details.tags != null)
            {
                for(int i = 0; i < details.tags.Length; i++)
                {
                    request.AddField($"tags[{i}]", details.tags[i]);
                }
            }

            if(details.HasLogo())
            {
                var logo = details.GetLogo();
                request.AddField("logo", $"logo.{logo.extension}", logo.data);
            }

            return request;
        }
    }
}
