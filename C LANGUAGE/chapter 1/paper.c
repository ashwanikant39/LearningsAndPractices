#include <stdio.h>

int main()
{
    float cost_price, selling_price, profit, loss;

    // Input cost price and selling price
    printf("Enter the cost price of the item: ");
    scanf("%f", &cost_price);
    printf("Enter the selling price of the item: ");
    scanf("%f", &selling_price);

    // Calculate profit or loss
    if (selling_price > cost_price)
    {
        profit = selling_price - cost_price;
        printf("Seller has made a profit of %.2f\n", profit);
    }
    else if (selling_price < cost_price)
    {
        loss = cost_price - selling_price;
        printf("Seller has incurred a loss of %.2f\n", loss);
    }
    else
    {
        printf("No profit, no loss.\n");
    }
    return 0;
}
