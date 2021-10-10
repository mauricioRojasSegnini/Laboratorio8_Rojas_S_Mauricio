class DataTable {
    constructor(dataOrigin, context) {
        this.dataOrigin = dataOrigin;
        this.context = context;
    }

    fillContext() {
        fetch(this.dataOrigin)
            .then(response => {
                return response.json();
            })
            .then(data => {
                var tableData = [];
                var tableRow = "";
                for (var i = 0; i < 2; i++) {
                    tableRow += `{id:${data[i].Id}, name:"${data[i].Name}", Quantity:${data[i].Quantity}, Price:${data[i].Price}  },`;          
                }
                tableData.push(tableRow);
                console.log(tableRow);
                //initialize table
                var table = new Tabulator("#ProductsContext", {
                    data: tableData, //assign data to table
                    autoColumns: true, //create columns from data field names
                });
                this.context.innerHTML = data;
            })
            .catch(error => {
                console.log(error);
            })
    }
}