using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Øvelse3
{
    internal class Mailer
    {
        private string firstName;
        private string lastName;
        private int age;
        private string address;
        private int postalCode;
        private string city;
        private string country;
        private string email;

        public Mailer(string firstName, string lastName, int age, string address, int postalCode, string city, string country, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.address = address;
            this.postalCode = postalCode;
            this.city = city;
            this.country = country;
            this.email = email;
        }

        // Getters
        public string get_fullName()
        {
            return $"{firstName} {lastName}";
        }
        public string get_firstName()
        {
            return firstName;
        }
        public string get_lastName()
        {
            return lastName;
        }

        public string get_fullAddress()
        {
            return $"{address}, {Convert.ToString(postalCode)}, {city}, {country}";
        }
        public string get_address()
        {
            return address;
        }
        public int get_postalCode()
        {
            return postalCode;
        }
        public string get_city()
        {
            return city;
        }
        public string get_country()
        {
            return country;
        }

        public int get_age()
        {
            return age;
        }

        public string get_email()
        {
            return email;
        }

        //Setters
        public void set_firstName(string firstName)
        {
            this.firstName = firstName;
        }
        public void set_lastName(string lastName)
        {
            this.lastName = lastName;
        }
        public void set_age(int age)
        {
            this.age = age;
        }
        public void set_address(string address)
        {
            this.address = address;
        }
        public void set_postalCode(int postalCode)
        {
            this.postalCode = postalCode;
        }
        public void set_city(string city)
        {
            this.city = city;
        }
        public void set_country(string country)
        {
            this.country = country;
        }
        public void set_email(string email)
        {
            Regex regexpression = new Regex("(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])");
            if (regexpression.IsMatch(email)) {
                this.email = email;
            } else
            {
                this.email = "N/A";
            }
        }
    }
}
