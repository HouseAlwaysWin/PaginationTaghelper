using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace PaginationTagHelper.Extensions
{
    public static class DynamicLinqExtensions
    {
        public static IOrderedQueryable<TSource> OrderBy<TSource>(
            this IQueryable<TSource> query, string propertyName)
        {
            var entityType = typeof(TSource);

            // Create x=>x.PropName
            var propertyInfo = entityType.GetProperty(propertyName);
            ParameterExpression arg = Expression.Parameter(entityType, "x");
            MemberExpression property = Expression.Property(arg, propertyName);
            var selector = Expression.Lambda(
                property, new ParameterExpression[] { arg });

            //Get System.Linq.Queryable.OrderBy() method
            var enumerableType = typeof(System.Linq.Queryable);
            var method = enumerableType.GetMethods()
                .Where(m => m.Name == "OrderBy" && m.IsGenericMethodDefinition)
                .Where(m =>
                {
                    var parameters = m.GetParameters().ToList();

                    //Put more restriction here to ensure selecting the right overload        

                    //overload that has 2 parameters
                    return parameters.Count == 2;
                }).Single();

            //The linq's OrderBy<TSource, TKey> has two generic types, which provided here
            MethodInfo genericMethod = method.MakeGenericMethod(
                entityType, propertyInfo.PropertyType);

            /*Call query.OrderBy(selector), with query and selector: x=> x.PropName
              Note that we pass the selector as Expression to the method and we don't compile it.
              By doing so EF can extract "order by" columns and generate SQL for it.*/
            var newQuery = (IOrderedQueryable<TSource>)genericMethod
                .Invoke(genericMethod, new object[] { query, selector });

            return newQuery;
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource>(
            this IEnumerable<TSource> query, string propertyName)
        {
            var entityType = typeof(TSource);

            // Create x=>x.PropName
            var propertyInfo = entityType.GetProperty(propertyName);
            ParameterExpression arg = Expression.Parameter(entityType, "x");
            MemberExpression property = Expression.Property(arg, propertyName);
            var selector = Expression.Lambda(
                property, new ParameterExpression[] { arg });

            //Get System.Linq.Queryable.OrderBy() method
            var enumerableType = typeof(System.Linq.Enumerable);
            var method = enumerableType.GetMethods()
                .Where(m => m.Name == "OrderBy" && m.IsGenericMethodDefinition)
                .Where(m =>
                {
                    var parameters = m.GetParameters().ToList();

                    return parameters.Count == 2;
                }).Single();

            MethodInfo genericMethod = method.MakeGenericMethod(
                entityType, propertyInfo.PropertyType);

            var newQuery = (IOrderedEnumerable<TSource>)genericMethod
                .Invoke(genericMethod, new object[] { query, selector });

            return newQuery;
        }


        public static IOrderedQueryable<TSource> OrderByDescending<TSource>(
            this IQueryable<TSource> query, string propertyName)
        {
            var entityType = typeof(TSource);

            // Create x=>x.PropName
            var propertyInfo = entityType.GetProperty(propertyName);
            ParameterExpression arg = Expression.Parameter(entityType, "x");
            MemberExpression property = Expression.Property(arg, propertyName);
            var selector = Expression.Lambda(
                property, new ParameterExpression[] { arg });

            //Get System.Linq.Queryable.OrderBy() method
            var enumerableType = typeof(System.Linq.Queryable);
            var method = enumerableType.GetMethods()
                .Where(m => m.Name == "OrderByDescending" && m.IsGenericMethodDefinition)
                .Where(m =>
                {
                    var parameters = m.GetParameters().ToList();

                    return parameters.Count == 2;
                }).Single();

            MethodInfo genericMethod = method.MakeGenericMethod(
                entityType, propertyInfo.PropertyType);

            var newQuery = (IOrderedQueryable<TSource>)genericMethod
                .Invoke(genericMethod, new object[] { query, selector });

            return newQuery;
        }


        public static IOrderedEnumerable<TSource> OrderByDescending<TSource>(
           this IEnumerable<TSource> query, string propertyName)
        {
            var entityType = typeof(TSource);

            // Create x=>x.PropName
            var propertyInfo = entityType.GetProperty(propertyName);
            ParameterExpression arg = Expression.Parameter(entityType, "x");
            MemberExpression property = Expression.Property(arg, propertyName);
            var selector = Expression.Lambda(
                property, new ParameterExpression[] { arg });

            //Get System.Linq.Queryable.OrderBy() method
            var enumerableType = typeof(System.Linq.Enumerable);
            var method = enumerableType.GetMethods()
                .Where(m => m.Name == "OrderByDescending" && m.IsGenericMethodDefinition)
                .Where(m =>
                {
                    var parameters = m.GetParameters().ToList();

                    return parameters.Count == 2;
                }).Single();

            MethodInfo genericMethod = method.MakeGenericMethod(
                entityType, propertyInfo.PropertyType);

            var newQuery = (IOrderedEnumerable<TSource>)genericMethod
                .Invoke(genericMethod, new object[] { query, selector });

            return newQuery;
        }

        public static IEnumerable<TSource> Where<TSource>(
            this IEnumerable<TSource> query, string propertyName,string containsString)
        {
            var entityType = typeof(TSource);
            // Create x=>x.PropName
            var propertyInfo = entityType.GetProperty(propertyName);
            // x =>
            ParameterExpression args = Expression.Parameter(entityType, "x");
            var entity_property = entityType.GetProperty(propertyName);
            // x=>x.Id
            MemberExpression property = Expression.Property(args,
                entityType.GetProperty(propertyName));

            // Convert to string, x.Id.ToString()
            var convert = Expression.Call(Expression.Convert(property, typeof(object)),
                typeof(object).GetMethod("ToString"));


            var right = Expression.Constant(containsString);

            // Get contains method from property
            MethodInfo contains_method =
                            typeof(string).GetMethod("Contains", new[] { typeof(string) });

            // x.Id.ToString().Contains(compareString)
            var contains = Expression.Call(convert, contains_method, right);

            // x=>x.Id.ToString().Contains(compareString)
            var result = Expression.Lambda(
                contains, new ParameterExpression[] { args });

            var enumerableType = typeof(Enumerable);
            // Find linq queryable method Where and parameter is two
            var method = enumerableType.GetMethods()
                .Where(m => m.Name == "Where" && m.IsGenericMethodDefinition)
                .Where(m =>
                {
                    var parameters = m.GetParameters();

                    return parameters.Count() == 2;
                }).First();

            // Use generic method according property
            MethodInfo genericMethod = method.MakeGenericMethod(
                            entityType);
            // Invoke IEnumerable<TSource> Where<TSource>(
            //    this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            var newQuery = (IEnumerable<TSource>)genericMethod
                            .Invoke(genericMethod, new object[] { query, result });
            return newQuery;
        }

        public static IQueryable<TSource> Where<TSource>(
            this IQueryable<TSource> query, string propertyName, string containsString)
        {
            var entityType = typeof(TSource);
            // Create x=>x.PropName
            var propertyInfo = entityType.GetProperty(propertyName);
            // x =>
            ParameterExpression args = Expression.Parameter(entityType, "x");
            var entity_property = entityType.GetProperty(propertyName);
            // x=>x.Id
            MemberExpression property = Expression.Property(args,
                entityType.GetProperty(propertyName));

            // Convert to string, x.Id.ToString()
            var convert = Expression.Call(Expression.Convert(property, typeof(object)),
                typeof(object).GetMethod("ToString"));


            var right = Expression.Constant(containsString);

            // Get contains method from property
            MethodInfo contains_method =
                            typeof(string).GetMethod("Contains", new[] { typeof(string) });

            // x.Id.ToString().Contains(compareString)
            var contains = Expression.Call(convert, contains_method, right);

            // x=>x.Id.ToString().Contains(compareString)
            var result = Expression.Lambda(
                contains, new ParameterExpression[] { args });

            var enumerableType = typeof(System.Linq.Queryable);
            // Find linq queryable method Where and parameter is two
            var method = enumerableType.GetMethods()
                .Where(m => m.Name == "Where" && m.IsGenericMethodDefinition)
                .Where(m =>
                {
                    var parameters = m.GetParameters();

                    return parameters.Count() == 2;
                }).First();

            // Use generic method according property
            MethodInfo genericMethod = method.MakeGenericMethod(
                            entityType);
            // Invoke IEnumerable<TSource> Where<TSource>(
            //    this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            var newQuery = (IQueryable<TSource>)genericMethod
                            .Invoke(genericMethod, new object[] { query, result });
            return newQuery;
        }

    }
}
