using System.Collections.Generic;

namespace EventEase.Services
{
    public class AttendanceService
    {
        private readonly Dictionary<string, HashSet<string>> _attendance = new();

        public void MarkAttendance(string eventName, string userEmail)
        {
            if (!_attendance.ContainsKey(eventName))
                _attendance[eventName] = new HashSet<string>();
            _attendance[eventName].Add(userEmail);
        }

        public bool HasAttended(string eventName, string userEmail)
        {
            return _attendance.ContainsKey(eventName) && _attendance[eventName].Contains(userEmail);
        }

        public IEnumerable<string> GetAttendees(string eventName)
        {
            return _attendance.ContainsKey(eventName) ? _attendance[eventName] : new HashSet<string>();
        }
    }
}
