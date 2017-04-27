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
    public partial class frmAnuncio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //pesquisar dados

            if (!IsPostBack)
            {

                using (ClassificadosContext ctx = new ClassificadosContext())
                {
                    var listaAnuncios = ctx.Anuncios.ToList();

                    var query = from anun in ctx.Anuncios
                                join a in ctx.Anunciantes
                                on anun.AnuncioID equals a.AnuncianteID
                                select new
                                {
                                    anun.AnuncioID,
                                    anun.Tipo,
                                    anun.Titulo,
                                    anun.Descricao,
                                    a.AnuncianteID,
                                    a.Nome,
                                };


                    //preencher o dataset
                    dsAnuncio dataSet = new dsAnuncio();

                    foreach (var anun in query)
                    {
                        // dsAnuncio.dtAnunciosRow linha = new dsAnuncio.dtAnunciosRow();
                        dataSet.dtAnuncios.AdddtAnunciosRow(
                            anun.AnuncioID,
                            anun.Titulo,
                            anun.Tipo,
                            anun.Descricao,
                            anun.AnuncianteID,
                            anun.Nome
                            );


                    }

                    ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;


                    //caminho do arquivo dorelatório(layout)
                    ReportViewer1.LocalReport.ReportPath = @"Relatorios\rptAnuncios.rdlc";

                    //limpando fonte de dados
                    ReportViewer1.LocalReport.DataSources.Clear();

                    //definir novas fontes de dados
                    ReportViewer1.LocalReport.DataSources.Add(
                        new Microsoft.Reporting.WebForms.ReportDataSource(
                            "dsAnuncio", (DataTable)dataSet.dtAnuncios

                            )

                        );

                    ReportViewer1.LocalReport.Refresh();
                }


            }






        }
    }
}