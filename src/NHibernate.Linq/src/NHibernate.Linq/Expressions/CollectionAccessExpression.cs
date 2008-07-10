﻿using System;
using System.Linq;
using System.Linq.Expressions;
using NHibernate.Type;
using NHibernate.Metadata;

namespace NHibernate.Linq.Expressions
{
    public class CollectionAccessExpression : PropertyAccessExpression
    {
        private readonly EntityExpression _elementExpression;

        public EntityExpression ElementExpression
        {
            get { return _elementExpression; }
        }

        public CollectionAccessExpression(string name, System.Type type, IType nhibernateType,
            EntityExpression expression, EntityExpression elementExpression)
            : base(name, type, nhibernateType, expression, NHibernateExpressionType.CollectionAccess)
        {
            _elementExpression = elementExpression;
        }
    }
}
