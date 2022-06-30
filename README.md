# BugCount
Bug Count - Report total issues across different projects (20/07/2018)

This tool was created during my apprenticeship to gather the total number of bugs/issues found across a large number of different projects. It's a replacement to a manual weekly reporting task. In which each QA Analyst would manually collect bug totals for stakeholders, giving visibility to how well projects were performing. 

This project originally started out of my own frustration to our previous process. I found the manual task of sorting through bug counts each week laborious and a waste of valuable time. Additionally, it relied on all members being present to report counts for their projects. And so, the weekly report was often incomplete with team members not present. With this all-in mind I wanted to create an automated process to retrieve this data instead. 

## How does it work?
First you need to create a query in Azure DevOps or Jira to report the bugs/issues for the project you want to report on. Then placing the URL to the query and the relevant personal auth token in the code will allow on demand reporting of the number of bugs/issues returned in the query.
