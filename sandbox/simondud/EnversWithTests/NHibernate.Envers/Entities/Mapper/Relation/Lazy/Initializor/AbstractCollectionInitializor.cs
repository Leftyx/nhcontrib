﻿using System;
using System.Collections.Generic;
using NHibernate.Envers.Configuration;
using NHibernate.Envers.Entities.Mapper.Relation.Query;
using NHibernate.Envers.Reader;

namespace NHibernate.Envers.Entities.Mapper.Relation.Lazy.Initializor
{
    /**
     * Initializes a persistent collection.
     * @author Adam Warski (adam at warski dot org)
     */
    public abstract class AbstractCollectionInitializor<T> : IInitializor<T>
	{
        private readonly IAuditReaderImplementor versionsReader;
        private readonly IRelationQueryGenerator queryGenerator;
        private readonly object primaryKey;
        
        protected readonly long revision;
        protected readonly EntityInstantiator entityInstantiator;

        public AbstractCollectionInitializor(AuditConfiguration verCfg,
											IAuditReaderImplementor versionsReader,
											IRelationQueryGenerator queryGenerator,
											object primaryKey, 
											long revision) {
            this.versionsReader = versionsReader;
            this.queryGenerator = queryGenerator;
            this.primaryKey = primaryKey;
            this.revision = revision;

            entityInstantiator = new EntityInstantiator(verCfg, versionsReader);
        }

        protected abstract ICollection<T> InitializeCollection(int size);

        protected abstract void AddToCollection(object collection, object collectionRow);

        public ICollection<T> Initialize() 
		{
            var collectionContent = queryGenerator.GetQuery(versionsReader, primaryKey, revision).List();

            var collection = InitializeCollection(collectionContent.Count);

            foreach (var collectionRow in collectionContent) 
			{
                AddToCollection(collection, collectionRow);
            }

            return collection;
        }
    }
}
