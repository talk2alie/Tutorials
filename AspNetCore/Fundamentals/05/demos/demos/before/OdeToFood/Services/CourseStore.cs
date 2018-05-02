using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    public class CourseStore
    {
        public CourseStore(DocumentClient client, Uri uri)
        {
            _client = client;
            _coursesLink = uri;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            var courses = _client.CreateDocumentQuery<Course>(_coursesLink)
                           .OrderBy(c => c.Title).ToList();
            return courses;
        }

        public async Task InsertCourses(IEnumerable<Course> courses)
        {
            foreach (var course in courses)
            {
                await _client.CreateDocumentAsync(_coursesLink, course);
            }
        }

        Uri _coursesLink;
        DocumentClient _client;
    }
}
