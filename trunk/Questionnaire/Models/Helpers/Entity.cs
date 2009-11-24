using System;
using System.Collections;

namespace Questionnaire.Models
{
    public class Entity
    {
        public string Id
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }
    }

    public class EntityCollection : CollectionBase
    {
        public Entity this[ int index ]
        {
            get { return ( Entity )( List[ index ] ); }
            set { List[ index ] = value; }
        }

        public int Add ( Entity entity )
        {
            return List.Add ( entity );
        }
    }
}