﻿namespace DsK.AuthServer.Client.Services.Routes
{
    public static class UserEndpoints
    {
        public static string Get(int id, int pageNumber, int pageSize, string searchString, string orderBy)
        {
            var url = $"users?Id={id}&pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy={orderBy}";
            return url;
        }

        public static string Post = "users";
        public static string Put = "users";
    }
}
