using CarWash.IntegrationTests.Fixtures;
using Xunit;

namespace CarWash.IntegrationTests.Collections;

[CollectionDefinition(nameof(PostgresCollection))]
public class PostgresCollection : ICollectionFixture<PostgresFixture>
{
}
