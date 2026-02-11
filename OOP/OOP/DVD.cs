using System;

namespace OOP
{
    internal class DVD : LibraryItem
    {
        public string Director { get; set; }
        public int Duration { get; set; }

        public DVD(string id, string title, string director, int duration, int publishedYear)
            : base(id, title, publishedYear)
        {
            Director = director;
            Duration = duration;
        }

        public override string GetInfo()
        {
            string availability = IsAvailable ? "Tillgänglig" : "Utlånad";
            int hours = Duration / 60;
            int minutes = Duration % 60;
            string durationText = hours > 0 ? $"{hours}h {minutes}min" : $"{minutes}min";

            return $"Typ: DVD\n" +
                   $"ID: {Id}\n" +
                   $"Titel: {Title}\n" +
                   $"Regissör: {Director}\n" +
                   $"Speltid: {durationText}\n" +
                   $"Utgivningsår: {PublishedYear}\n" +
                   $"Status: {availability}";
        }
    }
}
