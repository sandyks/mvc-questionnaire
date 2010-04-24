<%@ 
    Page 
        Inherits="System.Web.Mvc.ViewPage<Questionnaire.Models.EntityCollection>" 
        Language="C#" 
%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
    <head>
        <meta http-equiv="content-type" content="text/html; charset=utf-8" />
        <link href="<%= Url.Content ( "~/Includes/Styles/Screen.css" ) %>" media="screen" rel="stylesheet" type="text/css" />
        <title>Questionnaire</title>
    </head>
    <body>
        <div id="container">
            <h1>Questionnaire</h1>
            <div id="form">
                <fieldset>
                    <ol>
<% 
    if ( Model != null && ( ( Questionnaire.Models.EntityCollection )Model ).Count > 0 )
    {
        foreach ( Questionnaire.Models.Question question in Model )
        {
%>
                        <li>
                            <form action="" method="post">
                                <div><%= Html.Encode ( question.Value )%></div>
                                <ul>
<% 
            foreach ( Questionnaire.Models.Answer answer in question.Answers )
            {
%>
                                    <li><%= Html.RadioButton ( "SubmittedAnswerId", answer.Id )%><%= Html.Encode ( answer.Value )%></li>
<%
                }
%>
                                </ul>
                                <%= Html.Hidden ( "Id", question.Id )%>
                            </form>
                        </li>
<%
            }
        }
%>
                    </ol>
                </fieldset>
            </div>
            <div id="footer">
                <div><input class="button" type="button" value="Submit" /></div>
                <dl>
                    <dt id="personName"><%= Questionnaire.Models.Person.Name %></dt>
                    <dd>
                        <table>
                            <thead>
                                <tr>
                                    <th>Questions</th>
                                    <th width="20%">Number</th>
                                </tr>
                            </thead>
                            <tfoot>
                                <tr id="score">
                                    <td>Score</td>
                                    <td align="right"><span>0</span></td>
                                </tr>
                            </tfoot>
                            <tbody>
                                <tr id="correct">
                                    <td>Correct</td>
                                    <td align="right"><span>0</span></td>
                                </tr>
                                <tr id="incorrect">
                                    <td>Incorrect</td>
                                    <td align="right"><span>0</span></td>
                                </tr>
                            </tbody>
                        </table>
                    </dd>
                </dl>
            </div>
        </div>
        <script src="<%= Url.Content ( "~/Includes/Scripts/jquery.js" ) %>" type="text/javascript"></script>
        <script src="<%= Url.Content ( "~/Includes/Scripts/Common.js" ) %>" type="text/javascript"></script>
        <script src="<%= Url.Content ( "~/Includes/Scripts/Home.js" ) %>" type="text/javascript"></script>
        <script type="text/javascript">
            Questionnaire.Home.Index();
        </script>
    </body>
</html>