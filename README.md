# :bulb: Table-per-type (tpt)

Here in this example we have to implement an application for insurance companies. These companies have to deal with two entity 

. Policy
. Endorsement

> [!TIP]
> Indorsement being used when broker want's to add or edit some rules in covered context of a policy

So base on this requirement every single entity of type **Indorsement** are dependant to an entity of type **Policy**. In matter of fact we can't update context of a policy when it does not exist 
so we need two table with a 1v1 relationship and some sort of dependency in child table so it won't get any new record while there is no responsible record in parent table.

With these introduction's the **TPT** design for application's database would be suitable.

### Ef configuration
```cs
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
	modelBuilder.Entity<Policy>()
		.UseTptMappingStrategy();
}
```

applying this configuration on parent would be enough.

### Database 
```sql

CREATE TABLE [Policy] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NULL,
    [EffectionDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    [CoveringAmount] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Policy] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Endorsement] (
    [Id] int NOT NULL,
    [EndorsementEffectionDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Endorsement] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Endorsement_Policy_Id] FOREIGN KEY ([Id]) REFERENCES [Policy] ([Id]) ON DELETE CASCADE
);

GO
```