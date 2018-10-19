using Asm.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Asm.Service
{
    class ApiHandle
    {
        public static string GET_UPLOAD_URL = "https://2-dot-backup-server-002.appspot.com/get-upload-token";
        public static string API_REGISTER = "https://2-dot-backup-server-002.appspot.com/_api/v2/members";
        public static string API_LOGIN = "https://2-dot-backup-server-002.appspot.com/_api/v2/members/authentication";
        public static string API_INFORMATION = "https://2-dot-backup-server-002.appspot.com/_api/v2/members/information";
        public static string API_CREATE_SONG = "https://2-dot-backup-server-002.appspot.com/_api/v2/songs";
        public static string API_MY_LIST_SONG = "https://2-dot-backup-server-002.appspot.com/_api/v2/songs/get-mine";
        public static string API_LATEST_SONG = "https://2-dot-backup-server-002.appspot.com/_api/v2/songs";
        public static string TOKEN_STRING = null;
        public static Member Loggedin_Member;

        public async static Task<HttpResponseMessage> Sign_Up(Member member)
        {
            HttpClient httpClient = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(member), System.Text.Encoding.UTF8, "application/json");
            var response =  httpClient.PostAsync(API_REGISTER, content).Result;
            return response;
        }

        public async static Task<HttpResponseMessage> Create_Song(Song song)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + TOKEN_STRING);
            var content = new StringContent(JsonConvert.SerializeObject(song), System.Text.Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(API_CREATE_SONG, content).Result;
            return response;
        }

        public static async Task<bool> GetInformation()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + Service.ApiHandle.TOKEN_STRING);
            var resp = client.GetAsync(Service.ApiHandle.API_INFORMATION).Result;
            var content = await resp.Content.ReadAsStringAsync();
            Loggedin_Member = JsonConvert.DeserializeObject<Member>(content);
            return Loggedin_Member != null;
        }
    }
}
