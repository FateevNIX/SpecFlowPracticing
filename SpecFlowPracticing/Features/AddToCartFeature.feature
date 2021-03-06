﻿Feature: AddToCartFeature
	Check adding products to cart

@someTag
Scenario: Adding several products to cart
	Given I navigate to the Home page
	When I search for the Blouse
	Then The search result page is shown
	And Results contains Blouse
	When I click on More button for first product
	Then Product details page is shown
	When I select Quantity, Size, and Colour
		| Quantity | Size | Colour |
		| 3        | L    | Black  |
	And I click on 'Add to cart' button
	Then "Product successfully added to your shopping cart" modal is shown
	When I click 'Continue shopping' button
	Then Product details page is shown
	When I search for the Dress
	Then The search result page is shown
	And Results contains Printed Summer Dress
	When I click on More button for first product
	Then Product details page is shown
	When I select Quantity, Size, and Colour
		| Quantity | Size | Colour |
		| 5        | M    | Orange |
	And I click on 'Add to cart' button
	Then "Product successfully added to your shopping cart" modal is shown
	When I click 'Proceed to checkout' button
	Then Cart page is shown
	And It has next products with properties
		| ProductName          | Colour | Size | Quantity | TotalPrice |
		| Blouse               | Black  | L    | 3        | $81.00     |
		| Printed Summer Dress | Orange | M    | 5        | $144.90    |

@someTag
Scenario: Adding several products to cart and verify their total sum at Cart page and remove one
	Given I navigate to the Home page
	When I search for the Blouse
	Then The search result page is shown
	When I click on More button for first product
	Then Product details page is shown
	When I click on 'Add to cart' button
	Then "Product successfully added to your shopping cart" modal is shown
	When I click 'Continue shopping' button
	Then Product details page is shown
	When I search for the t shirt
	Then The search result page is shown
	And Results contains Faded Short Sleeve T-shirts
	When I click on More button for first product
	Then Product details page is shown
	When I click on 'Add to cart' button
	Then "Product successfully added to your shopping cart" modal is shown
	When I click 'Proceed to checkout' button
	Then Cart page is shown
	And Total price of all products is '43.51'
	When I delete 'Faded Short Sleeve T-shirts' product from cart
	Then Only 'Blouse' product is displayed