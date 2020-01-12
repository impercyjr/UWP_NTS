using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using T1809E_UWP_DAPI.Models;

namespace T1809E_UWP_DAPI.Services
{
    public class MemberService
    {
        private static readonly string MemberInformationApiUrl = "https://2-dot-backup-server-002.appspot.com/_api/v2/members/information";
        public async Task<Member> GetMemberInformation(string token)
        {
            
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            var response = await httpClient.GetAsync(MemberInformationApiUrl);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Member>(stringContent);
            }
            return null;
        }
    }
}
