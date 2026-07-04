using LibrarySystem.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Entities
{
    public class Book:IDisplayable
    {
        public string Title { get; private set; }
        public string AuthorName { get; private set; }
        public string ISBN { get; private set; }
        public string Category { get; private set; }
        public int PublicationDate { get; private set; }

        public Book(string title, string authorName, string isbn, string category, int publicationDate)
        {
            Title = title;
            AuthorName = authorName;
            ISBN = isbn;
            Category = category;
            PublicationDate = publicationDate;
        }
        public Book(string iSBN, string title)
       :this(iSBN, title, "unkown", "general", 0)
        {

        }
        public string DisplayInformations() =>
            $"""
            SBN : {ISBN}
            Title : {Title}
            Author Name : {AuthorName}
            Category : {Category}
            Publication Date : {PublicationDate}
            """;

    }
}
