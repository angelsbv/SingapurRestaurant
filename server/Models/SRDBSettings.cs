namespace server.Models{
    public class SRDBSettings : ISRDBSettings { 
        public string DBstr { get; set; }
        public string DBname { get; set; }
        public string UsersCollection { get; set; }
    }

    public interface ISRDBSettings {
        string DBstr { get; set; }
        string DBname { get; set; }
        string UsersCollection { get; set; }
    } 
}