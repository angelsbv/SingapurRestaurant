namespace server.Models {
    public class AuthRequest{
        
        #nullable enable
        public string? username { get; set; }
        public string? email { get; set; }
        #nullable disable

        public string password { get; set; }
    }
}