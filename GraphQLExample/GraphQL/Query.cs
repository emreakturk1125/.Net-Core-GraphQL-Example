using System.Linq;
using GraphQLExample.Data;
using GraphQLExample.Models;
using HotChocolate;
using HotChocolate.Data;

namespace GraphQLExample.GraphQL
{
    /// <summary>
    /// Represents the queries available.
    /// </summary>
    [GraphQLDescription("Represents the queries available.")]
    public class Query
    {
        /// <summary>
        /// Gets the queryable <see cref="Platform"/>.
        /// </summary>
        /// <param name="context">The <see cref="AppDbContext"/>.</param>
        /// <returns>The queryable <see cref="Platform"/>.</returns>
        [UseDbContext(typeof(Context))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable platform.")]
        public IQueryable<Platform> GetPlatform([ScopedService] Context context)
        {
            return context.Platforms;
        }

        /// <summary>
        /// Gets the queryable <see cref="Command"/>.
        /// </summary>
        /// <param name="context">The <see cref="AppDbContext"/>.</param>
        /// <returns>The queryable <see cref="Command"/>.</returns>
        [UseDbContext(typeof(Context))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable command.")]
        public IQueryable<Command> GetCommand([ScopedService] Context context)
        {
            return context.Commands;
        }
    }
}
