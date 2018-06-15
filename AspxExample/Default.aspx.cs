using AspxExample.Models;
using AspxExample.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using System.Web.UI;

public partial class _Default : Page
{
    private const string xml =
            @"<?xml version=""1.0"" encoding=""UTF-8""?>
                <AllProjects>
                  <Proj>
                    <ProjectId>1234</ProjectId>
                    <ProjectNumber>Test Project 1</ProjectNumber>
                    <AllSubmissions>
                      <Sub Type=""Primary Submission"">
                        <SubmissionID>1</SubmissionID>
                        <SubmissionNumber>ABC_XYZ</SubmissionNumber>
                      </Sub>
                      <Sub Type=""Secondary Submission"">
                        <SubmissionID>1</SubmissionID>
                        <SubmissionNumber>ABC_XYZ_2</SubmissionNumber>
                      </Sub>
                    </AllSubmissions>
                  </Proj>
                  <Proj>
                    <ProjectId>5678</ProjectId>
                    <ProjectNumber>Test Project 2</ProjectNumber>
                    <AllSubmissions>
                      <Sub Type=""Primary Submission"">
                        <SubmissionID>1</SubmissionID>
                        <SubmissionNumber>BlahBlah</SubmissionNumber>
                      </Sub>
                      <Sub Type=""Secondary Submission"">
                        <SubmissionID>1</SubmissionID>
                        <SubmissionNumber>NadaNada</SubmissionNumber>
                      </Sub>
                    </AllSubmissions>
                  </Proj>
                    <Proj>
                    <ProjectId>9999</ProjectId>
                    <ProjectNumber>Test Project 3</ProjectNumber>
                  </Proj>
                </AllProjects>";

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dtGetData = new DataTable();
        dtGetData.Columns.Add("ProjectId");
        dtGetData.Columns.Add("Project Number");
        dtGetData.Columns.Add("Submission Sub Type");
        dtGetData.Columns.Add("SubmissionID");
        dtGetData.Columns.Add("SubmissionNumber");

        var data = GetData();
        foreach(var proj in data)
        {
            foreach(var sub in proj.AllSubmissions)
            {
                var dtRow = dtGetData.NewRow();
                dtRow[0] = proj.ProjectId;
                dtRow[1] = proj.ProjectNumber;
                dtRow[2] = sub.Type;
                dtRow[3] = sub.SubmissionId;
                dtRow[4] = sub.SubmissionNumber;

                dtGetData.Rows.Add(dtRow);
            }
        }

        grdXMLParse.DataSource = dtGetData;
        grdXMLParse.DataBind();
    }

    public List<Proj> GetData()
    {
        return XMLParserUtility.Deserialize<List<Proj>>(xml, "AllProjects");
    }
}