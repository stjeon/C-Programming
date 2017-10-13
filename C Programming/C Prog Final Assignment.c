
/*I declare that the attached assignment is wholly my own work in accordance
with Seneca Academic Policy.No part of this assignment has been copied
manually or electronically from any other source(including web sites) or
distributed to other students.
Name __Stephen Jeon__ Student ID _ssjeon_*/
/*Stephen Jeon -ssjeon-IPC144-20161*/

#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#define MAX_INVENTORY_SIZE 4
#define MAX_ITEMS 10

//Struct declaration for milestone 3
struct Cart {
	int sku [MAX_ITEMS];
	float price [MAX_ITEMS];
	int quantity [MAX_ITEMS];
	float totalCost;
	int size;
};

//Function Prototypes
void garbage();
void menu();
void clear();
int readInventory(const char filename[], int sku[], float price[]);
void displayInventory(const int sku[], const float price[]);
void checkPrice(const int sku[], const float price[]);
int searchInventory(const int sku[], const int item);
void displayCart(const struct Cart* pShoppingCart);
void addCart(struct Cart* pShoppingCart, const int sku[], const float price[]);
void removeCart(struct Cart* pShoppingCart);
void checkout(struct Cart* pShoppingCart);
int validate(const int low, const int high, int sel);


//Main Function
int main(){
	int sel;
	int SKU[MAX_INVENTORY_SIZE];
	float PRICE[MAX_INVENTORY_SIZE];
	const char filename[] = { "Inventory" };
	//initialized myCart to 0 to avoid getting garbage address values.
	struct Cart myCart = { 0 };
	myCart.size = 0;

	//Welcome message
	printf("Welcome to the Grocery Store\n");
	printf("============================\n");

	//Menu loop
	do{
		menu();
		scanf("%d", &sel);
		garbage();
		clear();
		validate(1, 8, sel);
		
		//Menu sequences
		if (sel == 1){
			printf("Inventory\n");
			printf("===========================\n");
			printf("Sku       Price\n");
			readInventory(filename, SKU, PRICE);
			printf("===========================\n");
		}

		if (sel == 2){
			checkPrice(SKU, PRICE);
		}

		if (sel == 3){
			displayCart(&myCart);
		}

		if (sel == 4){
			addCart(&myCart, SKU, PRICE);
		}

		if (sel == 5){
			removeCart(&myCart);
		}

		if (sel == 6){
			checkout(&myCart);
		}

		//Goodbye sequence
		if (sel == 8){					
			printf("Goodbye!");
		}

	} while (sel != 8);

return 0;
}

//Garbage collector function(Optional Function)
void garbage(){
	while (getchar() != '\n');
}

//Menu Function 
void menu(){
	printf("Please select from the following options\n");
	printf("1) Display the inventory\n");
	printf("2) Price check\n");
	printf("3) Display my shopping cart\n");
	printf("4) Add to cart\n");
	printf("5) Remove from cart\n");
	printf("6) Check out\n");
	printf("7) Clear screen\n");
	printf("8)Exit\n");
}


/*Validator Function
variable 'sel'=user's menu selection*/
int validate(const int low, const int high, int sel) {					

		if (sel<low || sel>high)
			printf("invalid input, try again\n");

	return sel;
}

//Clearscreen Function
void clear(){
	int i;

	for (i = 0; i < 4; i++){
		printf("\n""\n""\n""\n""\n""\n""\n""\n""\n""\n");
	}
}

//Milestone 2 section

//Display inventory function (selection 1)
void displayInventory(const int sku[], const float price[]){
	int i;

	//For loop goes through the array and prints the sku # and price of the inventory.
	for (i = 0; i < MAX_INVENTORY_SIZE; i++)
		printf("%d %10.2f\n", sku[i], price[i]);
}

//Search function for selection 2
int searchInventory(const int sku[], const int item){
	int i;

	//returns the inputted sku # in the form 'i'.
	for (i = 0; i < MAX_INVENTORY_SIZE; i++){
		if (sku[i] == item)
			return i;
	}
	//-1 = false.
	return -1;
}

/*Price checker (selection 2)
sel= User's sku # selection
variable 'i'= result of search function*/
void checkPrice(const int sku[], const float price[]){
	int i, sel;

	printf("Please input the sku number of the item:\n");
		scanf("%d", &sel);
		//fit in garbage collector function for style.
			garbage();

		i=searchInventory(sku, sel);
			//false case.
			if (i == -1){
				printf("Item does not exist in shop! Please try again.\n");
			}
			//true case.
			else {
				printf("$%.2f\n", price[i]);
			}		
}

//Milestone 3 section

//Shopping cart displayer
void displayCart(const struct Cart* pShoppingCart) {
	int i;

	printf("==================================\n");
	printf("Sku        Quantity          Price\n");

	for (i = 0; i < MAX_INVENTORY_SIZE; i++){
		//sequence searches through the quantity array of the cart for items that are above 0 quantity.
		if (pShoppingCart->quantity[i] > 0){
		//spacing done in printf statement to match the above title.
		printf("%d %14d %14.2f\n", pShoppingCart->sku[i], pShoppingCart->quantity[i], pShoppingCart->price[i]);
		}
	}
	printf("==================================\n");
}

/*Add item to cart function
'sel' for search function, 'sel2' for quantity function*/
void addCart(struct Cart* pShoppingCart, const int sku[], const float price[]){
	int sel,sel2,i;																			

	//loops until search function returns a false SKU value.
	do{
		printf("Please Input a SKU Number:\n");
		scanf("%d", &sel);

		i = searchInventory(sku, sel);

		if (i != -1){
			printf("Quantity:\n");
			scanf("%d", &sel2);
			//Incremented size and quantity arrays.
			pShoppingCart->sku[i] = sel;
			pShoppingCart->quantity[i] += sel2;
			//equalized cart price with main function's PRICE array.
			pShoppingCart->price[i] = price[i];
			pShoppingCart->size++;
			printf("Item Successfully Added!\n");
		}

		else if (i == -1) {
			garbage();
			printf("Item does not exist. Please try again\n");
		}
	} while (i == -1);
}

void removeCart(struct Cart* pShoppingCart){
	int i;

		if (pShoppingCart->size == 0){
			printf("Cart is Already Empty.\n");
		}

		if (pShoppingCart->size > 0) {
			//searches through the quantity array and sets elements to 0.
			for (i = 0; i < MAX_INVENTORY_SIZE; i++){
				pShoppingCart->quantity[i] = 0;
				pShoppingCart->size = 0;
			}printf("Cart Successfully Removed.\n");
		}
}

void checkout(struct Cart* pShoppingCart){
	int i;

	//loops through the price array and increments totalCost to the sum of it.
	for (i = 0; i < MAX_INVENTORY_SIZE; i++){
		if (pShoppingCart->quantity[i] > 0){
			//The final price= price * quantity.
			pShoppingCart->totalCost += pShoppingCart->price[i] * pShoppingCart->quantity[i];
		}
	}printf("Your Total is: $%.2f\n", pShoppingCart->totalCost);
	//total cost reset to refresh the checkout function.
	pShoppingCart->totalCost = 0;
}

//Milestone 4 Section

int readInventory(const char filename[], int sku[], float price[]){
	FILE *fp = NULL;
	int i;

	fp = fopen("inventory.dat", "r");
	if (fp != NULL){
		for (i = 0; i < MAX_INVENTORY_SIZE; i++){
			while (fscanf(fp, "%[^,],%[^'\n']", sku[i], price[i]) == 2)
				printf("%d" "%f", sku[i], price[i]);
			fclose(fp);

			return 0;
		}
	}
	else{
		printf("Failed to open file\n");
	}
	return -1;
}