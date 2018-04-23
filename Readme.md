# How to implement paddings for the GridView cells


<p>This example demonstrates how to create a custom GridView with the CellPadding property to specify paddings for its cells</p>


<h3>Description</h3>

The signature of GridViewInfo's CalcRowCellDrawInfoCore method was changed. Now the method accept six parameters: CalcRowCellDrawInfoCore(GridDataRowInfo ri, GridColumnInfoArgs ci, GridCellInfo cell, GridColumnInfoArgs nextColumn, bool calcEditInfo, GridRow nextRow)

<br/>


