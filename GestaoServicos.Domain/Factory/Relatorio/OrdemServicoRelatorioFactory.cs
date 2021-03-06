using GestaoServicos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace GestaoServicos.Domain.Factory.Relatorio
{
    public class OrdemServicoRelatorioFactory : RelatorioFactory
    {
        private readonly OrdemServicoRelatorioModel _ordemServicoRelatorioModel;
        public OrdemServicoRelatorioFactory(OrdemServicoRelatorioModel model)
        {
            _ordemServicoRelatorioModel = model;
        }
        public override string GerarHtmlRelatorio()
        {
            var ordemServico = _ordemServicoRelatorioModel.OrdemServico;
            
            return $@"<!DOCTYPE html>
                        <html lang='en'>
                        <head>
                            <meta charset='UTF-8'>
                            <meta http-equiv='X-UA-Compatible' content='IE=edge'>
                            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                            <title>Document</title>
                            <link rel='stylesheet' href='styles.css' />
                        </head>
                        <body>
                            <table border='2' style='width:100%;'>
                                <tbody>
                                    <tr>
                                        <td colspan='2' class='align-center'>
                                            <img src='{Directory.GetCurrentDirectory()}/logo_multilimp.jpg' width='120' />
                                        </td>
                                        <!-- <td rowspan='2' class='align-center'>Telefones</td> -->
                                        <td colspan='2' class='align-center'>
                                            ORDEM DE SERVIÇO
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td colspan='2' class='align-center'></td>
                                        <td class='align-right'>Nº</td>
                                        <td class='align-center'>{ordemServico.OrdemServicoId}</td>
                                    </tr>
                                    <tr>
                                    </tr>
                                    <tr>
                                        <td colspan='4'>
                                            <table style='width: 100%;'>
                                                <tr>
                                                    <td colspan='2'>Multilimp Serviços de Limpeza LTDA.</td>
                                                    <td class='align-right'>CNPJ:</td>
                                                    <td>11111111/1111-11</td>
                                                    <td class='align-right'>Data Agendamento</td>
                                                    <td>{ordemServico.DataAgendamento.ToString("dd/MM/yyyy")}</td>
                                                </tr>
                                                <tr>
                                                    <td colspan='6'>Avenida Teste Bloco C.</td>
                                                </tr>
                                                <tr>
                                                    <td colspan='2'>Cidade/Estado</td>
                                                    <td class='align-right'>CEP:</td>
                                                    <td>32071-128</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan='4'>
                                            <table style='width: 100%;' border='2'>
                                                <tr>
                                                    <td>Cliente:</td>
                                                    <td colspan='2'>{ordemServico.Cliente.Nome}</td>
                                                    <td class='align-right'>CPF/CNPJ:</td>
                                                    <td>{ordemServico.Cliente.CPFCNPJ}</td>
                                                </tr>
                                                <tr>
                                                    <td>Endereço:</td>
                                                    <td colspan='4'>{ordemServico.Cliente.Endereco?.Logradouro}</td>
                                                </tr>
                                                <tr>
                                                    <td>Bairro:</td>
                                                    <td colspan='2'>{ordemServico.Cliente.Endereco?.Bairro}</td>
                                                    <td class='align-right'>Fone:</td>
                                                    <td>{ordemServico.Cliente.Telefone?.DDD} {ordemServico.Cliente.Telefone?.Numero}</td>
                                                </tr>
                                                <tr>
                                                    <td>Cidade:</td>
                                                    <td colspan='2'>{ordemServico.Cliente.Endereco?.Cidade}</td>
                                                    <td class='align-right'>UF:</td>
                                                    <td>{ordemServico.Cliente.Endereco?.UF}</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan='4' style='height: 100px' class='valign-top'>
                                            Descrição do serviço:<br>
                                            {ordemServico.Descricao}
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan='4' style='height: 100px;' class='valign-top'>
                                            Observaçoes:
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan='4'>
                                            <table style='width: 100%;' border='1'>
                                                <tr>
                                                    <td rowspan='3' class='valign-bottom' style='width: 70%;'>
                                                        Atendente: <br/>
                                                    </td>
                                                    <td class='align-right'>Orçamento:</td>
                                                    <td class='align-center'>{ordemServico.Valor.ToString("f2", CultureInfo.CreateSpecificCulture("pt-br"))}</td>
                                                </tr>
                                                <tr>
                                                    <td class='align-right'>Desconto:</td>
                                                    <td class='align-center'>{ordemServico.Desconto.ToString("f2", CultureInfo.CreateSpecificCulture("pt-br"))}</td>
                                                </tr>
                                                <tr>
                                                    <td class='align-right'>TOTAL:</td>
                                                    <td class='align-center'>{ordemServico.ValorTotal.ToString("f2", CultureInfo.CreateSpecificCulture("pt-br"))}</td>
                                                </tr>
                                                <tr>
                                                    <td colspan='2' class='align-right'>Data da Execução:</td>
                                                    <td class='align-center'>{ordemServico.DataExecucao.ToString("dd/MM/yyyy")}</td>
                                                </tr>
                                                <tr>
                                                    <td colspan='2' class='align-right'>Vencimento da garantia:</td>
                                                    <td class='align-center'>{ordemServico.DataExecucao.AddDays(15).ToString("dd/MM/yyyy")}</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </body>
                        </html>";
        }
    }
}
