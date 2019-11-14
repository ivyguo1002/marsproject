Feature: SignIn
	As a user, I should be able to sign in successfuly with valid credential
	As a user, I should not be able to sign in successfully with invalid credentail

@auto
Scenario: Sign In with Valid Credential
	//Given I open browser and navigate to the SignIn Page
	Given I Click on the Sign In tab, input valid email address and password and Click on Login button
	Then I should be able to sign in successfully

@auto
Scenario: Sign In with Invalid Credential
	//Given I open browser and navigate to the SignIn Page
	Given I Click on the Sign In tab, input invalid email address and password and Click on Login button
	Then I should not be able to sign in successfully
