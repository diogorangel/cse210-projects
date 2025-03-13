#Diogo Rangel Dos Santos
from datetime import datetime
import math

# Prompts for user input
widht = float(input("Enter the width of the tire in mm(ex 205): "))
aspect_ratio = float(input("Enter the aspect ratio of the tire(ex 60): "))
diameter = float(input("Enter the diameter of the wheel in inches(ex 15): "))

# Calculate the tire volume using the given formula
volume = (math.pi * widht ** 2 * aspect_ratio * (widht * aspect_ratio + 2540 * diameter)) / 10000000000

# Get the current date
current_date = datetime.now().strftime("%Y-%m-%d")

# Displays the calculated volume
print(f"The approximate volume of the tire is {volume:.2f} liters")

# Write the data to the volumes.txt file
with open("volumes.txt", "a") as file:
    file.write(f"{current_date}, {widht}, {aspect_ratio}, {diameter}, {volume:.2f}\n")

# Display the data from the volumes.txt file
print("Data has been recorded to volumes.txt.")

#addtional feature : Suggest sizes based on volume range
if volume < 30:
    print("This is a small tire, tipically for compact cars.")
elif 30 <= volume < 50:
    print("This is a medium tire, suitable for sedans and small SUVs.")
else:
    print("This is a large tire, likely for trucks or larger SUVs.")