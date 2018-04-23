using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
namespace E274.Module.BusinessObjects {
    [DefaultClassOptions]
    public class Contact : Person {
        public Contact(DevExpress.Xpo.Session session)
            : base(session) {
            
        }
    }
}
