using Bank_krwi.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_krwi {
    class AuthorsSingleton {
        private static AuthorsSingleton instance;
        public List<Author> listaAutorow { get; private set; }

        private AuthorsSingleton() {
            listaAutorow = new List<Author> {
                new Author("Damian", "Osiecki", "Wtorkowa"),
                new Author("Kamil", "Tomczak", "Wtorkowa"),
                new Author("Piotr", "Jankowski", "Wtorkowa")
            };
        }

        public static AuthorsSingleton Instance {
            get {
                if(instance == null) {
                    instance = new AuthorsSingleton();
                }
                return instance;
            }
        }
    }
}
