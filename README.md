# The Supermarket Refactoring exercise

This is a variation of a popular kata described in http://codekata.com/kata/kata01-supermarket-pricing/. The aim of the exercise is to build an automated teller that can check out articles from a shopping cart. 

The supermarket has a catalog with different types of products (rice, apples, milk, toothbrushes,...). Each product has a price, and the total price of the shopping cart is the total of all the prices.

But the supermarket also runs special deals, e.g.
 - Buy two toothbrushes, get one free
 - 10% discount on rice
 - 20% discount on apples if you buy more than 10
 - Bags of 1 kg of oranges $4 instead of $5.

These are just examples: the actual special deals changes each week, so needs to be easily configurable.

## Goal

The goal of the exercise is to practice how to deal with legacy code which is a mess.

Currently the implementation currently able to handle the following scenarios 

 - The teller able to have a shopping cart with no special deals
 - The client can get a receipt with the list of purchases and the total price.
 - The teller able to handle the following special deal scenarios
    - Buy 2 get one free
    - 10% discount on a certain product (e.g. 10% discount on 1kg packets of rice)
    - Buy 2 at set amount 
    - Buy 5 at set amount 
 
 - The teller able to handle combinations of the above scenarios, when there is more than one special deal in the shopping cart items.

AND There is only ONE simply test.

The code is not great and doesnt follow any clean code & design principles, but we need to clean up in manner to be highly extendable and maintable and acceptive to change.  New special deals are needed and coming soon by the client. Although yet to be decided, when are they need to be added as quickly as possible to allow the clien to be competitive .
