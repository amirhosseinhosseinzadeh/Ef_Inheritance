# :bulb: Table-per-hierarchy (tph)

The default and prefered way to create objects base on each other is `tph` pattern.

In tph **EfCore** uses one single table to store records for multiple tables with an extra column announced as `Discriminator` to indicates each record belongs to which table.