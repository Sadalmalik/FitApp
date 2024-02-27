using System;

namespace Sadalmelik.FitApp.Main
{
    public class UserData
    {
        // Default Human
        public float weight = 80;
        public float height = 170;
        public DateTime birthday = new DateTime(1990, 1, 1);
        public UserSex UserSex = UserSex.Male;
        public float activity = 1; // 1 - Not active, 2 - extremely active

        public float Age => (DateTime.Now - birthday).Days / 365.25f;
    }
}