Feature: ViewVotes
navigate to model detail page 

Background: 
Given user open BuggyCars website

@votes
Scenario Outline: model cannot be voted without login
	Given user click Overall Rating
	When look for <Make> in overall rating list 
	And click make <Make> 
	Then Model <Model> should be in page
	When user click Model <Model>
	Then votes number should be the same between make page and model page
	And login required message should be in page
	Examples: 
	| Make   | Model |
	| Lancia | Delta |

@votes
Scenario: model cannot be voted twice
	Given user use valid credential login
	| UserName	  | Password	|
	| AmandaChen  | AaBbCc123!  |
	And user click Overall Rating
	When look for <Make> in overall rating list 
	And click make <Make> 
	Then Model <Model> should be in page
	When user click Model <Model>
	Then votes number should be the same between make page and model page
	And voted message should be in page
	Examples: 
	| Make		 | Model			   |
	| Alfa Romeo | Guilia Quadrifoglio |

