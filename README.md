# :bulb: Table-per-hierarchy (tph)

The default and prefered way to create objects base on each other is `tph` pattern.

In tph **EfCore** uses one single table to store records for multiple tables with an extra column announced as `Discriminator` to indicates each record belongs to which table.

In this Example we have 3 Entity .One single clase as **base** and two other as **derived**

1. Gadget
   - SmartPhone
   - SmartWatch


We can also indicate the `Discriminator` column name explicitly as shown in below :
```cs
builder.Entity<Gadget>()
    .HasDiscriminator<string>("Gadget_Type")
    .HasValue<SmartPhone>("SmartPhone")
    .HasValue<SmartWatch>("SmartWatch");
```

> [!TIP]
> Configuring the disc `Discriminator` column is like usual columns


In some cases some of derived **Entities** can have simmilar columns (In name and type etc ..) This type of columns being reperesent as `Shared Columns`.

By default, when two sibling entity types in the hierarchy have a property with the same name, they will be mapped to two separate columns. But if their attributes being feat to eachother they can be map in a single column.

```cs
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<WebSite>()
        .Property(b => b.Url)
        .HasColumnName("Url");

    modelBuilder.Entity<EmailAddress>()
        .Property(b => b.Url)
        .HasColumnName("Url");
}
```

### The result

![tph](https://github.com/amirhosseinhosseinzadeh/Ef_Inheritance/assets/77617352/333814c3-c77f-443b-b00c-f4cdbc570f0b)



