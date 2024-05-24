// Name: Ashwani Kant
// Roll No: 2104939
// Branch: Voc. IT

#include <stdio.h>

#define NUM_YEARS 5
#define NUM_CITIES 5

// Function to find the maximum temperature for a city
float findMaxTemperature(float temperatures[]) {
    float maxTemperature = temperatures[0];
    for (int i = 1; i < NUM_YEARS; i++) {
        if (temperatures[i] > maxTemperature) {
            maxTemperature = temperatures[i];
        }
    }
    return maxTemperature;
}

// Function to find the minimum temperature for a city
float findMinTemperature(float temperatures[]) {
    float minTemperature = temperatures[0];
    for (int i = 1; i < NUM_YEARS; i++) {
        if (temperatures[i] < minTemperature) {
            minTemperature = temperatures[i];
        }
    }
    return minTemperature;
}

int main() {
    float yearlyTemperatures[NUM_CITIES][NUM_YEARS];
    float maxTemp, minTemp;

    // Input average yearly temperatures for each city
    for (int i = 0; i < NUM_CITIES; i++) {
        printf("Enter the average yearly temperatures for city %d:\n", i + 1);
        for (int j = 0; j < NUM_YEARS; j++) {
            printf("Year %d: ", j + 1);
            scanf("%f", &yearlyTemperatures[i][j]);
        }
    }

    // Display maximum and minimum temperatures for each city
    for (int i = 0; i < NUM_CITIES; i++) {
        maxTemp = findMaxTemperature(yearlyTemperatures[i]);
        minTemp = findMinTemperature(yearlyTemperatures[i]);
        printf("\nCity %d:\n", i + 1);
        printf("Maximum Temperature: %.2f\n", maxTemp);
        printf("Minimum Temperature: %.2f\n", minTemp);
    }

    return 0;
}
