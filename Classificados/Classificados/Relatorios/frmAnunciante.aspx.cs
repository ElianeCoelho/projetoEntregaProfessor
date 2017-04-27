using Classificados.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Classificados.Relatorios
{
    public partial class frmAnunciante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                using (ClassificadosContext ctx = new ClassificadosContext())
                {
                    var listaAnunciante = ctx.Anunciantes.ToList();

    

                    //preencher o dataset
                    dsAnunciante dataSet = new dsAnunciante();

                    foreach (Anunciante a in listaAnunciante)
                    {
                        // dsAnuncio.dtAnunciosRow linha = new dsAnuncio.dtAnunciosRow();
                        dataSet.dtAnunciante.AdddtAnuncianteRow(
                            a.AnuncianteID,
                            a.Nome,
                            a.Cpf,
                            a.Endereco
                            );


                    }

                   
                    ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;


                    //caminho do arquivo dorelatório(layout)
                    ReportViewer1.LocalReport.ReportPath = @"Relatorios\rptAnunciante.rdlc";

                    //limpando fonte de dados
                    ReportViewer1.LocalReport.DataSources.Clear();

                    //definir novas fontes de dados
                    ReportViewer1.LocalReport.DataSources.Add(
                        new Microsoft.Reporting.WebForms.ReportDataSource(
                            "dsAnunciante", (DataTable)dataSet.dtAnunciante

                            )

                        );

                    ReportViewer1.LocalReport.Refresh();
                }


            }

        }
    }
}