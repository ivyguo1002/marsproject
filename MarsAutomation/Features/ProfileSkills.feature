Feature: ProfileSkills
	As a user
	I should be able to add/edit/delete skills

@auto
Scenario: Add a skill
	Given I Click on Skills tab
	When I Add a new skill
	Then The skill should be added successfully
@auto
Scenario: Edit a skill
	Given I Click on Skills tab
	When I Edit a skill
	Then The skill should be updated successfully
@auto
Scenario: Delete a skill
	Given I Click on Skills tab
	When I delete a skill
	Then The skill should be deleted successfully
