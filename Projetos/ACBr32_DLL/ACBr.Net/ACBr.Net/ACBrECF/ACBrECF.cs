﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBr.Net
{
	public class ACBrECF : ACBrComponent, IDisposable
	{
		#region Fields

		private ACBrECFAliquota[] aliquotas;
		private ACBrECFFormaPagamento[] formasPagamento;
		private ACBrECFComprovanteNaoFiscal[] comprovantesNaoFiscais;
		private ACBrAAC aac;

		#endregion Fields

		#region Constructor

		public ACBrECF()
		{
			Create(ACBrDll.ECF_Create);
		}

		#endregion Constructor

		#region Properties

		public ModeloECF Modelo
		{
			get
			{
				return (ModeloECF)GetInt32(ACBrDll.ECF_GetModelo);
			}
			set
			{
				SetInt32(ACBrDll.ECF_SetModelo, (int)value);
			}
		}

		public string Porta
		{
			get
			{
				return GetString(ACBrDll.ECF_GetPorta);
			}
			set
			{
				SetString(ACBrDll.ECF_SetPorta, value);
			}
		}

		public int Baud
		{
			get
			{
				return GetInt32(ACBrDll.ECF_GetBaud);
			}
			set
			{
				SetInt32(ACBrDll.ECF_SetBaud, value);
			}
		}

		public int DataBits
		{
			get
			{
				return GetInt32(ACBrDll.ECF_GetDataBits);
			}
			set
			{
				SetInt32(ACBrDll.ECF_SetDataBits, value);
			}
		}

		public SerialParity Parity
		{
			get
			{
				return (SerialParity)GetInt32(ACBrDll.ECF_GetParity);
			}
			set
			{
				SetInt32(ACBrDll.ECF_SetParity, (int)value);
			}
		}

		public SerialStopBits StopBits
		{
			get
			{
				return (SerialStopBits)GetInt32(ACBrDll.ECF_GetStopBits);
			}
			set
			{
				SetInt32(ACBrDll.ECF_SetStopBits, (int)value);
			}
		}

		public SerialHandShake HandShake
		{
			get
			{
				return (SerialHandShake)GetInt32(ACBrDll.ECF_GetHandShake);
			}
			set
			{
				SetInt32(ACBrDll.ECF_SetHandShake, (int)value);
			}
		}

		public bool HardFlow
		{
			get
			{
				return GetBool(ACBrDll.ECF_GetHardFlow);
			}
			set
			{
				SetBool(ACBrDll.ECF_SetHardFlow, value);
			}
		}

		public bool SoftFlow
		{
			get
			{
				return GetBool(ACBrDll.ECF_GetSoftFlow);
			}
			set
			{
				SetBool(ACBrDll.ECF_SetSoftFlow, value);
			}
		}

		public int TimeOut
		{
			get
			{
				return GetInt32(ACBrDll.ECF_GetTimeOut);
			}
			set
			{
				SetInt32(ACBrDll.ECF_SetTimeOut, value);
			}
		}

		public bool Ativo
		{
			get
			{
				return GetBool(ACBrDll.ECF_GetAtivo);
			}
		}

		public int Colunas
		{
			get
			{
				return GetInt32(ACBrDll.ECF_GetColunas);
			}
		}

		public bool AguardandoResposta
		{
			get
			{
				return GetBool(ACBrDll.ECF_GetAguardandoResposta);
			}
		}

		public string ComandoLog
		{
			get
			{
				return GetString(ACBrDll.ECF_GetComandoLOG);
			}
			set
			{
				SetString(ACBrDll.ECF_SetComandoLOG, value);
			}
		}

		public bool AguardaImpressao
		{
			get
			{
				return GetBool(ACBrDll.ECF_GetAguardaImpressao);
			}
			set
			{
				SetBool(ACBrDll.ECF_SetAguardaImpressao, value);
			}
		}

		public string ModeloStr
		{
			get
			{
				return GetString(ACBrDll.ECF_GetModeloStr);
			}
		}

		public string RFDID
		{
			get
			{
				return GetString(ACBrDll.ECF_GetRFDID);
			}
		}

		public DateTime DataHora
		{
			get
			{
				return GetDateTime(ACBrDll.ECF_GetDataHora);
			}
		}

		public string NumCupom
		{
			get
			{
				return GetString(ACBrDll.ECF_GetNumCupom);
			}
		}

		public string NumCOO
		{
			get
			{
				return GetString(ACBrDll.ECF_GetNumCOO);
			}
		}

		public string NumLoja
		{
			get
			{
				return GetString(ACBrDll.ECF_GetNumLoja);
			}
		}

		public string NumECF
		{
			get
			{
				return GetString(ACBrDll.ECF_GetNumECF);
			}
		}

		public string NumSerie
		{
			get
			{
				return GetString(ACBrDll.ECF_GetNumSerie);
			}
		}

		public string NumVersao
		{
			get
			{
				return GetString(ACBrDll.ECF_GetNumVersao);
			}
		}

		public DateTime DataMovimento
		{
			get
			{
				return GetDateTime(ACBrDll.ECF_GetDataMovimento);
			}
		}

		public DateTime DataHoraSB
		{
			get
			{
				return GetDateTime(ACBrDll.ECF_GetDataHoraSB);
			}
		}

		public string CNPJ
		{
			get
			{
				return GetString(ACBrDll.ECF_GetCNPJ);
			}
		}

		public string IE
		{
			get
			{
				return GetString(ACBrDll.ECF_GetIE);
			}
		}

		public string IM
		{
			get
			{
				return GetString(ACBrDll.ECF_GetIM);
			}
		}

		public string Cliche
		{
			get
			{
				return GetString(ACBrDll.ECF_GetCliche);
			}
		}

		public string UsuarioAtual
		{
			get
			{
				return GetString(ACBrDll.ECF_GetUsuarioAtual);
			}
		}

		public string SubModeloECF
		{
			get
			{
				return GetString(ACBrDll.ECF_GetSubModeloECF);
			}
		}

		public string PAF
		{
			get
			{
				return GetString(ACBrDll.ECF_GetPAF);
			}
		}

		public string NumCRZ
		{
			get
			{
				return GetString(ACBrDll.ECF_GetNumCRZ);
			}
		}

		public string NumCRO
		{
			get
			{
				return GetString(ACBrDll.ECF_GetNumCRO);
			}
		}

		public string NumCCF
		{
			get
			{
				return GetString(ACBrDll.ECF_GetNumCCF);
			}
		}

		public string NumGNF
		{
			get
			{
				return GetString(ACBrDll.ECF_GetNumGNF);
			}
		}

		public string NumGRG
		{
			get
			{
				return GetString(ACBrDll.ECF_GetNumGRG);
			}
		}

		public string NumCDC
		{
			get
			{
				return GetString(ACBrDll.ECF_GetNumCDC);
			}
		}

		public string NumCOOInicial
		{
			get
			{
				return GetString(ACBrDll.ECF_GetNumCOOInicial);
			}
		}

		public decimal VendaBruta
		{
			get
			{
				return GetDecimal(ACBrDll.ECF_GetVendaBruta);
			}
		}

		public decimal GrandeTotal
		{
			get
			{
				return GetDecimal(ACBrDll.ECF_GetGrandeTotal);
			}
		}

		public decimal TotalCancelamentos
		{
			get
			{
				return GetDecimal(ACBrDll.ECF_GetTotalCancelamentos);
			}
		}

		public decimal TotalDescontos
		{
			get
			{
				return GetDecimal(ACBrDll.ECF_GetTotalDescontos);
			}
		}

		public decimal TotalAcrescimos
		{
			get
			{
				return GetDecimal(ACBrDll.ECF_GetTotalAcrescimos);
			}
		}

		public decimal TotalTroco
		{
			get
			{
				return GetDecimal(ACBrDll.ECF_GetTotalTroco);
			}
		}

		public decimal TotalSubstituicaoTributaria
		{
			get
			{
				return GetDecimal(ACBrDll.ECF_GetTotalSubstituicaoTributaria);
			}
		}

		public decimal TotalNaoTributado
		{
			get
			{
				return GetDecimal(ACBrDll.ECF_GetTotalNaoTributado);
			}
		}

		public decimal TotalIsencao
		{
			get
			{
				return GetDecimal(ACBrDll.ECF_GetTotalIsencao);
			}
		}

		public decimal TotalCancelamentosISSQN
		{
			get
			{
				return GetDecimal(ACBrDll.ECF_GetTotalCancelamentosISSQN);
			}
		}

		public decimal TotalDescontosISSQN
		{
			get
			{
				return GetDecimal(ACBrDll.ECF_GetTotalDescontosISSQN);
			}
		}

		public decimal TotalAcrescimosISSQN
		{
			get
			{
				return GetDecimal(ACBrDll.ECF_GetTotalAcrescimosISSQN);
			}
		}

		public decimal TotalSubstituicaoTributariaISSQN
		{
			get
			{
				return GetDecimal(ACBrDll.ECF_GetTotalSubstituicaoTributariaISSQN);
			}
		}

		public decimal TotalNaoTributadoISSQN
		{
			get
			{
				return GetDecimal(ACBrDll.ECF_GetTotalNaoTributadoISSQN);
			}
		}

		public decimal TotalIsencaoISSQN
		{
			get
			{
				return GetDecimal(ACBrDll.ECF_GetTotalIsencaoISSQN);
			}
		}

		public decimal TotalNaoFiscal
		{
			get
			{
				return GetDecimal(ACBrDll.ECF_GetTotalNaoFiscal);
			}
		}

		public int NumUltItem
		{
			get
			{
				return GetInt32(ACBrDll.ECF_GetNumUltItem);
			}
		}

		public bool EmLinha
		{
			get
			{
				const int DEFAULT_TIMEOUT = 1;
				int ret = ACBrDll.ECF_GetEmLinha(this.Handle, DEFAULT_TIMEOUT);
				CheckResult(ret);

				return Convert.ToBoolean(ret);
			}
		}

		public bool PoucoPapel
		{
			get
			{
				return GetBool(ACBrDll.ECF_GetPoucoPapel);
			}
		}

		public EstadoECF Estado
		{
			get
			{
				return (EstadoECF)GetInt32(ACBrDll.ECF_GetEstado);
			}
		}

		public bool HorarioVerao
		{
			get
			{
				return GetBool(ACBrDll.ECF_GetHorarioVerao);
			}
		}

		public bool Arredonda
		{
			get
			{
				return GetBool(ACBrDll.ECF_GetArredonda);
			}
		}

		public bool Termica
		{
			get
			{
				return GetBool(ACBrDll.ECF_GetTermica);
			}
		}

		public bool MFD
		{
			get
			{
				return GetBool(ACBrDll.ECF_GetMFD);
			}
		}

		public bool IdentificaConsumidorRodape
		{
			get
			{
				return GetBool(ACBrDll.ECF_GetIdentificaConsumidorRodape);
			}
		}

		public decimal SubTotal
		{
			get
			{
				return GetDecimal(ACBrDll.ECF_GetSubTotal);
			}
		}

		public decimal TotalPago
		{
			get
			{
				return GetDecimal(ACBrDll.ECF_GetTotalPago);
			}
		}

		public bool GavetaAberta
		{
			get
			{
				return GetBool(ACBrDll.ECF_GetGavetaAberta);
			}
		}

		public bool ChequePronto
		{
			get
			{
				return GetBool(ACBrDll.ECF_GetChequePronto);
			}
		}

		public int IntervaloAposComando
		{
			get
			{
				return GetInt32(ACBrDll.ECF_GetIntervaloAposComando);
			}
			set
			{
				SetInt32(ACBrDll.ECF_SetIntervaloAposComando, value);
			}
		}

		public bool DescricaoGrande
		{
			get
			{
				return GetBool(ACBrDll.ECF_GetDescricaoGrande);
			}
			set
			{
				SetBool(ACBrDll.ECF_SetDescricaoGrande, value);
			}
		}

		public bool GavetaSinalInvertido
		{
			get
			{
				return GetBool(ACBrDll.ECF_GetGavetaSinalInvertido);
			}
			set
			{
				SetBool(ACBrDll.ECF_SetGavetaSinalInvertido, value);
			}
		}

		public string Operador
		{
			get
			{
				return GetString(ACBrDll.ECF_GetOperador);
			}
			set
			{
				SetString(ACBrDll.ECF_SetOperador, value);
			}
		}

		public int LinhasEntreCupons
		{
			get
			{
				return GetInt32(ACBrDll.ECF_GetLinhasEntreCupons);
			}
			set
			{
				SetInt32(ACBrDll.ECF_SetLinhasEntreCupons, value);
			}
		}

		public int DecimaisPreco
		{
			get
			{
				return GetInt32(ACBrDll.ECF_GetDecimaisPreco);
			}
			set
			{
				SetInt32(ACBrDll.ECF_SetDecimaisPreco, value);
			}
		}

		public int DecimaisQtd
		{
			get
			{
				return GetInt32(ACBrDll.ECF_GetDecimaisQtd);
			}
			set
			{
				SetInt32(ACBrDll.ECF_SetDecimaisQtd, value);
			}
		}

		public ACBrECFAliquota[] Aliquotas
		{
			get
			{
				if (aliquotas == null) this.CarregaAliquotas();
				return (ACBrECFAliquota[])aliquotas.Clone();
			}
		}

		public ACBrECFFormaPagamento[] FormasPagamento
		{
			get
			{
				if (formasPagamento == null) CarregaFormasPagamento();
				return (ACBrECFFormaPagamento[])formasPagamento;
			}
		}

		public ACBrECFComprovanteNaoFiscal[] ComprovantesNaoFiscais
		{
			get
			{
				if (comprovantesNaoFiscais == null) CarregaComprovantesNaoFiscais();
				return (ACBrECFComprovanteNaoFiscal[])comprovantesNaoFiscais;
			}
		}

		public string DadosReducaoZ
		{
			get
			{
				const int BUFFER_LEN = 16384;
				return GetString(ACBrDll.ECF_GetDadosReducaoZ, BUFFER_LEN);
			}
		}

		public string DadosUltimaReducaoZ
		{
			get
			{
				const int BUFFER_LEN = 16384;
				return GetString(ACBrDll.ECF_GetDadosUltimaReducaoZ, BUFFER_LEN);
			}
		}

		public ACBrECFDadosRZ DadosReducaoZClass
		{
			get
			{
				return GetDadosReducaoZClass();
			}
		}

		#endregion Properties

		#region Methods

		#region Métodos Ativar/Desativar

		public void Ativar()
		{
			int ret = ACBrDll.ECF_Ativar(this.Handle);
			CheckResult(ret);
		}

		public void Desativar()
		{
			int ret = ACBrDll.ECF_Desativar(this.Handle);
			CheckResult(ret);
		}

		#endregion Métodos Ativar/Desativar

		#region Métodos do Cupom Fiscal

		public void IdentificaConsumidor(string cpfCnpj, string nome, string endereco)
		{
			int ret = ACBrDll.ECF_IdentificaConsumidor(this.Handle, ToUTF8(cpfCnpj), ToUTF8(nome), ToUTF8(endereco));
			CheckResult(ret);
		}

		public void AbreCupom(string cpfCnpj, string nome, string endereco)
		{
			int ret = ACBrDll.ECF_AbreCupom(this.Handle, ToUTF8(cpfCnpj), ToUTF8(nome), ToUTF8(endereco));
			CheckResult(ret);
		}

		public void LegendaInmetroProximoItem()
		{
			int ret = ACBrDll.ECF_LegendaInmetroProximoItem(this.Handle);
			CheckResult(ret);
		}

		public void VendeItem(string codigo, string descricao, string aliquotaICMS, decimal qtd, decimal valorUnitario, decimal descontoPorc, string unidade, string tipoDescontoAcrescimo, string descontoAcrescimo)
		{
			int ret = ACBrDll.ECF_VendeItem(this.Handle, ToUTF8(codigo), ToUTF8(descricao), ToUTF8(aliquotaICMS), (double)qtd, (double)valorUnitario, (double)descontoPorc, ToUTF8(unidade), ToUTF8(tipoDescontoAcrescimo), ToUTF8(descontoAcrescimo));
			CheckResult(ret);
		}

		public void DescontoAcrescimoItemAnterior(decimal valorDesconto, string descontoAcrescimo)
		{
			int ret = ACBrDll.ECF_DescontoAcrescimoItemAnterior(this.Handle, (double)valorDesconto, ToUTF8(descontoAcrescimo));
			CheckResult(ret);
		}

		public void SubtotalizaCupom(decimal descontoAcrescimo, string mensagemRodape)
		{
			int ret = ACBrDll.ECF_SubtotalizaCupom(this.Handle, (double)descontoAcrescimo, ToUTF8(mensagemRodape));
			CheckResult(ret);
		}

		public void EfetuaPagamento(string codFormaPagto, decimal valor, string observacao, bool imprimeVinculado)
		{
			int ret = ACBrDll.ECF_EfetuaPagamento(this.Handle, ToUTF8(codFormaPagto), (double)valor, ToUTF8(observacao), imprimeVinculado);
			CheckResult(ret);
		}

		public void EstornaPagamento(string codFormaPagtoEstornar, string codFormaPagtoEfetivar, double valor, string observacao)
		{
			int ret = ACBrDll.ECF_EstornaPagamento(this.Handle, ToUTF8(codFormaPagtoEstornar), ToUTF8(codFormaPagtoEfetivar), valor, ToUTF8(observacao));
		}

		public void FechaCupom(string observacao)
		{
			int ret = ACBrDll.ECF_FechaCupom(this.Handle, ToUTF8(observacao));
			CheckResult(ret);
		}

		public void CancelaCupom()
		{
			int ret = ACBrDll.ECF_CancelaCupom(this.Handle);
			CheckResult(ret);
		}

		public void CancelaItemVendido(int numItem)
		{
			int ret = ACBrDll.ECF_CancelaItemVendido(this.Handle, numItem);
			CheckResult(ret);
		}

		public void CancelaItemVendidoParcial(int numItem, decimal quantidade)
		{
			int ret = ACBrDll.ECF_CancelaItemVendidoParcial(this.Handle, numItem, (double)quantidade);
			CheckResult(ret);
		}

		public void CancelaDescontoAcrescimoItem(int numItem)
		{
			int ret = ACBrDll.ECF_CancelaDescontoAcrescimoItem(this.Handle, numItem);
		}

		public void CancelaDescontoAcrescimoSubTotal(string tipoAcrescimoDesconto)
		{
			int ret = ACBrDll.ECF_CancelaDescontoAcrescimoSubTotal(this.Handle, tipoAcrescimoDesconto[0]);
			CheckResult(ret);
		}

		#endregion Métodos do Cupom Fiscal

		#region Métodos DAV
		public void DAV_Abrir(DateTime emissao, string decrdocumento, string numero, string situacao, string vendedor, string observacao, string cpfCnpj, string nome, string endereco)
        {
			int ret = ACBrDll.ECF_DAV_Abrir(this.Handle, emissao.ToOADate(), ToUTF8(decrdocumento),
				ToUTF8(numero), ToUTF8(situacao), ToUTF8(vendedor), ToUTF8(observacao),
				ToUTF8(cpfCnpj), ToUTF8(nome), ToUTF8(endereco));
			CheckResult(ret);
		}

		public void DAV_RegistrarItem(string codigo, string descricao, string unidade, double quantidade, double vlrunitario, double desconto, double acrescimo, bool cancelado)
        {
			int ret = ACBrDll.ECF_DAV_RegistrarItem(this.Handle, ToUTF8(codigo), ToUTF8(descricao), ToUTF8(unidade),
			quantidade, vlrunitario, desconto, acrescimo, cancelado);
			CheckResult(ret);
		}

		public void DAV_Fechar(string observacao)
		{
			int ret = ACBrDll.ECF_DAV_Fechar(this.Handle, ToUTF8(observacao));
			CheckResult(ret);
		}

        private void PafMF_RelDAVEmitidos(List<ACBrECFDAVs> DAVs, string TituloRelatorio, string IndiceRelatorio)
        {
            ACBrDll.DAVsRec[] record = new ACBrDll.DAVsRec[DAVs.Count];
            for (int i = 0; i < DAVs.Count; i++)
            {
                record[i].Numero = DAVs[i].Numero;
                record[i].COO_Cupom = DAVs[i].COO_Cupom;
                record[i].COO_Dav = DAVs[i].COO_Dav;
                record[i].Titulo = DAVs[i].Titulo;
                record[i].DtEmissao = DAVs[i].DtEmissao.ToOADate();
                record[i].Valor = DAVs[i].Valor;
            }

            int ret = ACBrDll.ECF_PafMF_RelDAVEmitidos(this.Handle, record, DAVs.Count, ToUTF8(TituloRelatorio), ToUTF8(IndiceRelatorio));
            CheckResult(ret);
        }
		#endregion Métodos DAV

        #region PAF
        public void PafMF_GerarCAT52(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
        {
            int ret = ACBrDll.ECF_PafMF_GerarCAT52(this.Handle, DataInicial.ToOADate(), DataFinal.ToOADate(), ToUTF8(CaminhoArquivo));
            CheckResult(ret);
        }

        public void PafMF_LX_Impressao()
        {
            int ret = ACBrDll.ECF_PafMF_LX_Impressao(this.Handle);
            CheckResult(ret);
        } 
        #endregion

        #region PAF LMFC
        public void PafMF_LMFC_Cotepe1704(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
        {
            int ret = ACBrDll.ECF_PafMF_LMFC_Cotepe1704(this.Handle, DataInicial.ToOADate(), DataFinal.ToOADate(), ToUTF8(CaminhoArquivo));
            CheckResult(ret);
        }

        public void PafMF_LMFC_Cotepe1704(int CRZInicial, int CRZFinal, string CaminhoArquivo)
        {
            int ret = ACBrDll.ECF_PafMF_LMFC_Cotepe1704_CRZ(this.Handle, CRZInicial, CRZFinal, ToUTF8(CaminhoArquivo));
            CheckResult(ret);
        }

        public void PafMF_LMFC_Espelho(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
        {
            int ret = ACBrDll.ECF_PafMF_LMFC_Espelho(this.Handle, DataInicial.ToOADate(), DataFinal.ToOADate(), ToUTF8(CaminhoArquivo));
            CheckResult(ret);
        }

        public void PafMF_LMFC_Espelho(int CRZInicial, int CRZFinal, string CaminhoArquivo)
        {
            int ret = ACBrDll.ECF_PafMF_LMFC_Espelho_CRZ(this.Handle, CRZInicial, CRZFinal, ToUTF8(CaminhoArquivo));
            CheckResult(ret);
        }

        public void PafMF_LMFC_Impressao(DateTime DataInicial, DateTime DataFinal)
        {
            int ret = ACBrDll.ECF_PafMF_LMFC_Impressao(this.Handle, DataInicial.ToOADate(), DataFinal.ToOADate());
            CheckResult(ret);
        }

        public void PafMF_LMFC_Impressao(int CRZInicial, int CRZFinal)
        {
            int ret = ACBrDll.ECF_PafMF_LMFC_Impressao_CRZ(this.Handle, CRZInicial, CRZFinal);
            CheckResult(ret);
        }      
        #endregion

        #region PAF LMFS
        public void PafMF_LMFS_Espelho(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
        {
            int ret = ACBrDll.ECF_PafMF_LMFS_Espelho(this.Handle, DataInicial.ToOADate(), DataFinal.ToOADate(), ToUTF8(CaminhoArquivo));
            CheckResult(ret);
        }

        public void PafMF_LMFS_Espelho(int CRZInicial, int CRZFinal, string CaminhoArquivo)
        {
            int ret = ACBrDll.ECF_PafMF_LMFS_Espelho_CRZ(this.Handle, CRZInicial, CRZFinal, ToUTF8(CaminhoArquivo));
            CheckResult(ret);
        }

        public void PafMF_LMFS_Impressao(DateTime DataInicial, DateTime DataFinal)
        {
            int ret = ACBrDll.ECF_PafMF_LMFS_Impressao(this.Handle, DataInicial.ToOADate(), DataFinal.ToOADate());
            CheckResult(ret);
        }

        public void PafMF_LMFS_Impressao(int CRZInicial, int CRZFinal)
        {
            int ret = ACBrDll.ECF_PafMF_LMFS_Impressao_CRZ(this.Handle, CRZInicial, CRZFinal);
            CheckResult(ret);
        }
        #endregion

        #region PAF Espelho MFD
        public void PafMF_MFD_Cotepe1704(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
        {
            int ret = ACBrDll.ECF_PafMF_MFD_Cotepe1704(this.Handle, DataInicial.ToOADate(), DataFinal.ToOADate(), ToUTF8(CaminhoArquivo));
            CheckResult(ret);
        }

        public void PafMF_MFD_Cotepe1704(int COOInicial, int COOFinal, string CaminhoArquivo)
        {
            int ret = ACBrDll.ECF_PafMF_MFD_Cotepe1704_COO(this.Handle, COOInicial, COOFinal, ToUTF8(CaminhoArquivo));
            CheckResult(ret);
        }
        #endregion

        #region PAF Arq. MFD
        public void PafMF_MFD_Espelho(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo)
		{
			int ret = ACBrDll.ECF_PafMF_MFD_Espelho(this.Handle, DataInicial.ToOADate(), DataFinal.ToOADate(), ToUTF8(CaminhoArquivo));
			CheckResult(ret);
		}

		public void PafMF_MFD_Espelho(int COOInicial, int COOFinal, string CaminhoArquivo)
		{
			int ret = ACBrDll.ECF_PafMF_MFD_Espelho_COO(this.Handle, COOInicial, COOFinal, ToUTF8(CaminhoArquivo));
			CheckResult(ret);
		}

		#endregion PAF MFD

		#region Relatórios

		public void LeituraX()
		{
			int ret = ACBrDll.ECF_LeituraX(this.Handle);
			CheckResult(ret);
		}

		public void ReducaoZ()
		{
			int ret = ACBrDll.ECF_ReducaoZ(this.Handle);
			CheckResult(ret);
		}

		public void AbreRelatorioGerencial(int indice)
		{
			int ret = ACBrDll.ECF_AbreRelatorioGerencial(this.Handle, indice);
			CheckResult(ret);
		}

		public void LinhaRelatorioGerencial(string linha, int indiceBMP)
		{
			int ret = ACBrDll.ECF_LinhaRelatorioGerencial(this.Handle, ToUTF8(linha), indiceBMP);
			CheckResult(ret);
		}

		public void AbreCupomVinculado(int coo, string codFormaPagto, decimal valor)
		{
			var cooStr = string.Format("{0:000000}", coo);
			AbreCupomVinculado(cooStr, codFormaPagto, valor);
		}

		public void AbreCupomVinculado(string coo, string codFormaPagto, decimal valor)
		{
			int ret = ACBrDll.ECF_AbreCupomVinculado(this.Handle, ToUTF8(coo), ToUTF8(codFormaPagto), (double)valor);
			CheckResult(ret);
		}

		public void AbreCupomVinculado(string coo, string codFormaPagto, string codComprovanteNaoFiscal, decimal valor)
		{
			int ret = ACBrDll.ECF_AbreCupomVinculadoCNF(this.Handle, ToUTF8(coo), ToUTF8(codFormaPagto), ToUTF8(codComprovanteNaoFiscal), (double)valor);
			CheckResult(ret);
		}

		public void LinhaCupomVinculado(string linha)
		{
			int ret = ACBrDll.ECF_LinhaCupomVinculado(this.Handle, ToUTF8(linha));
			CheckResult(ret);
		}

		public void FechaRelatorio()
		{
			int ret = ACBrDll.ECF_FechaRelatorio(this.Handle);
			CheckResult(ret);
		}

		public void PulaLinhas(int numLinhas)
		{
			int ret = ACBrDll.ECF_PulaLinhas(this.Handle, numLinhas);
			CheckResult(ret);
		}

		public void CortaPapel(bool corteParcial)
		{
			int ret = ACBrDll.ECF_CortaPapel(this.Handle, corteParcial);
			CheckResult(ret);
		}

		public void CorrigeEstadoErro()
		{
			CorrigeEstadoErro(true);
		}

		public void CorrigeEstadoErro(bool reducaoZ)
		{
			int ret = ACBrDll.ECF_CorrigeEstadoErro(this.Handle, reducaoZ);
			CheckResult(ret);
		}

		public void LeituraMemoriaFiscal(int reducaoInicial, int reducaoFinal)
		{
			LeituraMemoriaFiscal(reducaoFinal, reducaoFinal, false);
		}

		public void LeituraMemoriaFiscal(int reducaoInicial, int reducaoFinal, bool simplificada)
		{
			int ret = ACBrDll.ECF_LeituraMemoriaFiscalReducao(this.Handle, reducaoInicial, reducaoFinal, simplificada);
			CheckResult(ret);
		}

		public void LeituraMemoriaFiscal(DateTime dataInicial, DateTime dataFinal)
		{
			LeituraMemoriaFiscal(dataInicial, dataFinal, false);
		}

		public void LeituraMemoriaFiscal(DateTime dataInicial, DateTime dataFinal, bool simplificada)
		{
			int ret = ACBrDll.ECF_LeituraMemoriaFiscalData(this.Handle, dataInicial.ToOADate(), dataFinal.ToOADate(), simplificada);
			CheckResult(ret);
		}

		public string LeituraMemoriaFiscalSerial(int reducaoInicial, int reducaoFinal)
		{
			return LeituraMemoriaFiscalSerial(reducaoInicial, reducaoFinal, false);
		}

		public string LeituraMemoriaFiscalSerial(int reducaoInicial, int reducaoFinal, bool simplificada)
		{
			const int LEN = 10 * 1024;
			StringBuilder buffer = new StringBuilder(LEN);

			int ret = ACBrDll.ECF_LeituraMemoriaFiscalSerialReducao(this.Handle, reducaoInicial, reducaoFinal, simplificada, buffer, LEN);
			CheckResult(ret);

			buffer.Length = ret;
			return FromUTF8(buffer);
		}

		public string LeituraMemoriaFiscalSerial(DateTime dataInicial, DateTime dataFinal)
		{
			return LeituraMemoriaFiscalSerial(dataInicial, dataFinal, false);
		}

		public string LeituraMemoriaFiscalSerial(DateTime dataInicial, DateTime dataFinal, bool simplificada)
		{
			const int LEN = 10 * 1024;
			StringBuilder buffer = new StringBuilder(LEN);

			int ret = ACBrDll.ECF_LeituraMemoriaFiscalSerialData(this.Handle, dataInicial.ToOADate(), dataFinal.ToOADate(), simplificada, buffer, LEN);
			CheckResult(ret);

			buffer.Length = ret;
			return FromUTF8(buffer);
		}

		public void LeituraMemoriaFiscalSerial(int reducaoInicial, int reducaoFinal, string nomeArquivo)
		{
			LeituraMemoriaFiscalSerial(reducaoInicial, reducaoFinal, ToUTF8(nomeArquivo), false);
		}

		public void LeituraMemoriaFiscalSerial(int reducaoInicial, int reducaoFinal, string nomeArquivo, bool simplificada)
		{
			int ret = ACBrDll.ECF_LeituraMemoriaFiscalArquivoReducao(this.Handle, reducaoInicial, reducaoFinal, ToUTF8(nomeArquivo), simplificada);
			CheckResult(ret);
		}

		public void LeituraMemoriaFiscalSerial(DateTime dataInicial, DateTime dataFinal, string nomeArquivo)
		{
			LeituraMemoriaFiscalSerial(dataInicial, dataFinal, ToUTF8(nomeArquivo), false);
		}

		public void LeituraMemoriaFiscalSerial(DateTime dataInicial, DateTime dataFinal, string nomeArquivo, bool simplificada)
		{
			int ret = ACBrDll.ECF_LeituraMemoriaFiscalArquivoData(this.Handle, dataInicial.ToOADate(), dataFinal.ToOADate(), ToUTF8(nomeArquivo), simplificada);
			CheckResult(ret);
		}

		private ACBrECFDadosRZ GetDadosReducaoZClass()
		{
			IntPtr ptr;
			int ret = ACBrDll.ECF_GetDadosReducaoZClass(this.Handle, out ptr);
			CheckResult(ret);

			try
			{
				ACBrECFDadosRZ dadosRZ = new ACBrECFDadosRZ();
				ACBrDll.DadosRZRec record = (ACBrDll.DadosRZRec)Marshal.PtrToStructure(ptr, typeof(ACBrDll.DadosRZRec));

				dadosRZ.COO = record.COO;
				dadosRZ.CFD = record.CFD;
				dadosRZ.CancelamentoISSQN = Convert.ToDecimal(record.CancelamentoISSQN);
				dadosRZ.GNFC = record.GNFC;
				dadosRZ.CRO = record.CRO;
				dadosRZ.ValorVendaBruta = Convert.ToDecimal(record.ValorVendaBruta);

				dadosRZ.TotalizadoresNaoFiscais = new ACBrECFComprovanteNaoFiscal[record.TotalizadoresNaoFiscaisLen];
				for (int i = 0; i < record.TotalizadoresNaoFiscaisLen; i++)
				{
					IntPtr itemPtr = new IntPtr(record.TotalizadoresNaoFiscais.ToInt32() + (i * Marshal.SizeOf(typeof(ACBrDll.ComprovanteNaoFiscalRec))));
					ACBrDll.ComprovanteNaoFiscalRec itemRec = (ACBrDll.ComprovanteNaoFiscalRec)Marshal.PtrToStructure(itemPtr, typeof(ACBrDll.ComprovanteNaoFiscalRec));

					ACBrECFComprovanteNaoFiscal item = new ACBrECFComprovanteNaoFiscal();
					item.Indice = FromUTF8(itemRec.Indice);
					item.PermiteVinculado = itemRec.PermiteVinculado;
					item.Descricao = FromUTF8(itemRec.Descricao);
					item.FormaPagamento = FromUTF8(itemRec.FormaPagamento);
					item.Total = Convert.ToDecimal(itemRec.Total);
					item.Contador = itemRec.Contador;

					dadosRZ.TotalizadoresNaoFiscais[i] = item;
				}

				dadosRZ.ICMS = new ACBrECFAliquota[record.ICMSLen];
				for (int i = 0; i < record.ICMSLen; i++)
				{
					IntPtr itemPtr = new IntPtr(record.ICMS.ToInt32() + (i * Marshal.SizeOf(typeof(ACBrDll.AliquotaRec))));
					ACBrDll.AliquotaRec itemRec = (ACBrDll.AliquotaRec)Marshal.PtrToStructure(itemPtr, typeof(ACBrDll.AliquotaRec));

					ACBrECFAliquota item = new ACBrECFAliquota();
					item.Indice = FromUTF8(itemRec.Indice);
					item.Aliquota = Convert.ToDecimal(itemRec.Aliquota);
					item.Tipo = Convert.ToString(itemRec.Tipo);
					item.Total = Convert.ToDecimal(itemRec.Total);
					item.Sequencia = itemRec.Sequencia;

					dadosRZ.ICMS[i] = item;
				}

				dadosRZ.AcrescimoICMS = Convert.ToDecimal(record.AcrescimoICMS);
				dadosRZ.DescontoICMS = Convert.ToDecimal(record.DescontoICMS);
				dadosRZ.NaoTributadoICMS = Convert.ToDecimal(record.NaoTributadoICMS);

				dadosRZ.RelatorioGerencial = new ACBrECFRelatorioGerencial[record.RelatorioGerencialLen];
				for (int i = 0; i < record.RelatorioGerencialLen; i++)
				{
					IntPtr itemPtr = new IntPtr(record.RelatorioGerencial.ToInt32() + (i * Marshal.SizeOf(typeof(ACBrDll.RelatorioGerencialRec))));
					ACBrDll.RelatorioGerencialRec itemRec = (ACBrDll.RelatorioGerencialRec)Marshal.PtrToStructure(itemPtr, typeof(ACBrDll.RelatorioGerencialRec));

					ACBrECFRelatorioGerencial item = new ACBrECFRelatorioGerencial();
					item.Indice = FromUTF8(itemRec.Indice);
					item.Descricao = FromUTF8(itemRec.Descricao);
					item.Contador = itemRec.Contador;

					dadosRZ.RelatorioGerencial[i] = item;
				}

				dadosRZ.CRZ = record.CRZ;

				dadosRZ.ISSQN = new ACBrECFAliquota[record.ISSQNLen];
				for (int i = 0; i < record.ISSQNLen; i++)
				{
					IntPtr itemPtr = new IntPtr(record.ISSQN.ToInt32() + (i * Marshal.SizeOf(typeof(ACBrDll.AliquotaRec))));
					ACBrDll.AliquotaRec itemRec = (ACBrDll.AliquotaRec)Marshal.PtrToStructure(itemPtr, typeof(ACBrDll.AliquotaRec));

					ACBrECFAliquota item = new ACBrECFAliquota();
					item.Indice = FromUTF8(itemRec.Indice);
					item.Aliquota = Convert.ToDecimal(itemRec.Aliquota);
					item.Tipo = Convert.ToString(itemRec.Tipo);
					item.Total = Convert.ToDecimal(itemRec.Total);
					item.Sequencia = itemRec.Sequencia;

					dadosRZ.ISSQN[i] = item;
				}

				dadosRZ.GRG = record.GRG;
				dadosRZ.ValorGrandeTotal = Convert.ToDecimal(record.ValorGrandeTotal);
				dadosRZ.AcrescimoISSQN = Convert.ToDecimal(record.AcrescimoISSQN);
				dadosRZ.NaoTributadoISSQN = Convert.ToDecimal(record.NaoTributadoISSQN);
				dadosRZ.IsentoICMS = Convert.ToDecimal(record.IsentoICMS);
				dadosRZ.SubstituicaoTributariaICMS = Convert.ToDecimal(record.SubstituicaoTributariaICMS);
				dadosRZ.DataDaImpressora = DateTime.FromOADate(record.DataDaImpressora);
				dadosRZ.TotalOperacaoNaoFiscal = Convert.ToDecimal(record.TotalOperacaoNaoFiscal);
				dadosRZ.DescontoISSQN = Convert.ToDecimal(record.DescontoISSQN);
				dadosRZ.CancelamentoOPNF = Convert.ToDecimal(record.CancelamentoOPNF);
				dadosRZ.AcrescimoOPNF = Convert.ToDecimal(record.AcrescimoOPNF);
				dadosRZ.DescontoOPNF = Convert.ToDecimal(record.DescontoOPNF);
				dadosRZ.CancelamentoICMS = Convert.ToDecimal(record.CancelamentoICMS);
				dadosRZ.GNF = record.GNF;
				dadosRZ.IsentoISSQN = Convert.ToDecimal(record.IsentoISSQN);
				dadosRZ.SubstituicaoTributariaISSQN = Convert.ToDecimal(record.SubstituicaoTributariaISSQN);
				dadosRZ.VendaLiquida = Convert.ToDecimal(record.VendaLiquida);
				dadosRZ.CFC = record.CFC;
				dadosRZ.CCF = record.CCF;
				dadosRZ.TotalISSQN = Convert.ToDecimal(record.TotalISSQN);
				dadosRZ.TotalICMS = Convert.ToDecimal(record.TotalICMS);
				dadosRZ.CDC = record.CDC;
				dadosRZ.CCDC = record.CCDC;
				dadosRZ.NCN = record.NCN;
				dadosRZ.DataDoMovimento = DateTime.FromOADate(record.DataDoMovimento);

				dadosRZ.MeiosDePagamento = new ACBrECFFormaPagamento[record.MeiosDePagamentoLen];
				for (int i = 0; i < record.MeiosDePagamentoLen; i++)
				{
					IntPtr itemPtr = new IntPtr(record.MeiosDePagamento.ToInt32() + (i * Marshal.SizeOf(typeof(ACBrDll.FormaPagamentoRec))));
					ACBrDll.FormaPagamentoRec itemRec = (ACBrDll.FormaPagamentoRec)Marshal.PtrToStructure(itemPtr, typeof(ACBrDll.FormaPagamentoRec));

					ACBrECFFormaPagamento item = new ACBrECFFormaPagamento();
					item.Indice = FromUTF8(itemRec.Indice);
					item.Descricao = FromUTF8(itemRec.Descricao);
					item.PermiteVinculado = itemRec.PermiteVinculado;
					item.Total = Convert.ToDecimal(itemRec.Total);

					dadosRZ.MeiosDePagamento[i] = item;
				}

				dadosRZ.NumeroCOOInicial = FromUTF8(record.NumeroCOOInicial);
				dadosRZ.NumeroDoECF = FromUTF8(record.NumeroDoECF);
				dadosRZ.NumeroDeSerie = FromUTF8(record.NumeroDeSerie);
				dadosRZ.NumeroDeSerieMFD = FromUTF8(record.NumeroDeSerieMFD);
				dadosRZ.NumeroDaLoja = FromUTF8(record.NumeroDaLoja);

				dadosRZ.TotalTroco = Convert.ToDecimal(record.TotalTroco);

				return dadosRZ;
			}
			finally
			{
				ret = ACBrDll.ECF_DestroyDadosReducaoZClass(this.Handle, ref ptr);
				CheckResult(ret);
			}
		}

		#endregion Relatórios

		#region Alíquotas

		public void CarregaAliquotas()
		{
			int count = ACBrDll.ECF_CarregaAliquotas(this.Handle);
			CheckResult(count);

			CarregaAliquotas(count);
		}

		private void CarregaAliquotas(int count)
		{
			aliquotas = new ACBrECFAliquota[count];

			for (int i = 0; i < count; i++)
			{
				var record = new ACBrDll.AliquotaRec();
				int ret = ACBrDll.ECF_GetAliquota(this.Handle, ref record, i);
				CheckResult(ret);

				ACBrECFAliquota aliquota = new ACBrECFAliquota();
				aliquota.Indice = FromUTF8(record.Indice);
				aliquota.Aliquota = Convert.ToDecimal(record.Aliquota);
				aliquota.Sequencia = record.Sequencia;
				aliquota.Tipo = record.Tipo.ToString();
				aliquota.Total = Convert.ToDecimal(record.Total);

				aliquotas[i] = aliquota;
			}
		}

		public void LerTotaisAliquota()
		{
			int count = ACBrDll.ECF_LerTotaisAliquota(this.Handle);
			CheckResult(count);

			CarregaAliquotas(count);
		}

		public void ProgramaAliquota(decimal aliquota, string tipo)
		{
			ProgramaAliquota(aliquota, tipo, string.Empty);
		}

		public void ProgramaAliquota(decimal aliquota, string tipo, string posicao)
		{
			if (string.IsNullOrEmpty(tipo)) throw new ArgumentException();

			int ret = ACBrDll.ECF_ProgramaAliquota(this.Handle, (double)aliquota, tipo[0], posicao);
			CheckResult(ret);
		}

		#endregion Alíquotas

		#region Formas de Pagto

		public void CarregaFormasPagamento()
		{
			int count = ACBrDll.ECF_CarregaFormasPagamento(this.Handle);
			CheckResult(count);

			CarregaFormasPagamento(count);
		}

		private void CarregaFormasPagamento(int count)
		{
			formasPagamento = new ACBrECFFormaPagamento[count];
			for (int i = 0; i < count; i++)
			{
				var record = new ACBrDll.FormaPagamentoRec();
				int ret = ACBrDll.ECF_GetFormaPagamento(this.Handle, ref record, i);
				CheckResult(ret);

				ACBrECFFormaPagamento formaPagamento = new ACBrECFFormaPagamento();
				formaPagamento.Indice = FromUTF8(record.Indice);
				formaPagamento.Descricao = FromUTF8(record.Descricao);
				formaPagamento.PermiteVinculado = record.PermiteVinculado;
				formaPagamento.Total = Convert.ToDecimal(record.Total);

				formasPagamento[i] = formaPagamento;
			}
		}

		public void LerTotaisFormaPagamento()
		{
			int count = ACBrDll.ECF_LerTotaisFormaPagamento(this.Handle);
			CheckResult(count);

			CarregaFormasPagamento(count);
		}

		public void ProgramaFormaPagamento(string descricao, bool permiteVinculado)
		{
			ProgramaFormaPagamento(descricao, permiteVinculado, string.Empty);
		}

		public void ProgramaFormaPagamento(string descricao, bool permiteVinculado, string posicao)
		{
			int ret = ACBrDll.ECF_ProgramaFormaPagamento(this.Handle, ToUTF8(descricao), permiteVinculado, ToUTF8(posicao));
			CheckResult(ret);
		}

		#endregion Formas de Pagto

		#region Comprovantes Não Fiscal

		public void CarregaComprovantesNaoFiscais()
		{
			int count = ACBrDll.ECF_CarregaComprovantesNaoFiscais(this.Handle);
			CheckResult(count);

			CarregaComprovantesNaoFiscais(count);
		}

		private void CarregaComprovantesNaoFiscais(int count)
		{
			comprovantesNaoFiscais = new ACBrECFComprovanteNaoFiscal[count];
			for (int i = 0; i < count; i++)
			{
				var record = new ACBrDll.ComprovanteNaoFiscalRec();
				int ret = ACBrDll.ECF_GetComprovanteNaoFiscal(this.Handle, ref record, i);
				CheckResult(ret);

				ACBrECFComprovanteNaoFiscal comprovanteNaoFiscal = new ACBrECFComprovanteNaoFiscal();
				comprovanteNaoFiscal.Indice = FromUTF8(record.Indice);
				comprovanteNaoFiscal.Descricao = FromUTF8(record.Descricao);
				comprovanteNaoFiscal.PermiteVinculado = record.PermiteVinculado;
				comprovanteNaoFiscal.FormaPagamento = FromUTF8(record.FormaPagamento);
				comprovanteNaoFiscal.Total = Convert.ToDecimal(record.Total);
				comprovanteNaoFiscal.Contador = record.Contador;

				comprovantesNaoFiscais[i] = comprovanteNaoFiscal;
			}
		}

		public void LerTotaisComprovanteNaoFiscal()
		{
			int count = ACBrDll.ECF_LerTotaisComprovanteNaoFiscal(this.Handle);
			CheckResult(count);

			CarregaComprovantesNaoFiscais(count);
		}

		public void ProgramaComprovanteNaoFiscal(string descricao, string tipo)
		{
			ProgramaComprovanteNaoFiscal(descricao, tipo, string.Empty);
		}

		public void ProgramaComprovanteNaoFiscal(string descricao, string tipo, string posicao)
		{
			if (string.IsNullOrEmpty(tipo)) throw new ArgumentException();

			int ret = ACBrDll.ECF_ProgramaComprovanteNaoFiscal(this.Handle, ToUTF8(descricao), ToUTF8(tipo), ToUTF8(posicao));
			CheckResult(ret);
		}

		public void AbreNaoFiscal(string cpfCnpj)
		{
			int ret = ACBrDll.ECF_AbreNaoFiscal(this.Handle, ToUTF8(cpfCnpj));
			CheckResult(ret);
		}

		public void RegistraItemNaoFiscal(string codCNF, decimal value, string obs)
		{
			int ret = ACBrDll.ECF_RegistraItemNaoFiscal(this.Handle, ToUTF8(codCNF), Convert.ToDouble(value), ToUTF8(obs));
			CheckResult(ret);
		}

		public void SubtotalizaNaoFiscal(decimal descontoAcrescimo, string mensagemRodape)
		{
			int ret = ACBrDll.ECF_SubtotalizaNaoFiscal(this.Handle, Convert.ToDouble(descontoAcrescimo), ToUTF8(mensagemRodape));
			CheckResult(ret);
		}

		public void EfetuaPagamentoNaoFiscal(string codFormaPagto, decimal valor, string observacao, bool imprimeVinculado)
		{
			int ret = ACBrDll.ECF_EfetuaPagamentoNaoFiscal(this.Handle, codFormaPagto, Convert.ToDouble(valor), observacao, imprimeVinculado);
			CheckResult(ret);
		}

		public void FechaNaoFiscal(string observacao)
		{
			int ret = ACBrDll.ECF_FechaNaoFiscal(this.Handle, ToUTF8(observacao));
			CheckResult(ret);
		}

		public void CancelaNaoFiscal()
		{
			int ret = ACBrDll.ECF_CancelaNaoFiscal(this.Handle);
			CheckResult(ret);
		}

		#endregion Comprovantes Não Fiscal

		#region Suprimento e Sangria

		public void Suprimento(decimal valor, string obs)
		{
			int ret = ACBrDll.ECF_Suprimento(this.Handle, (double)valor, ToUTF8(obs));
			CheckResult(ret);
		}

		public void Sangria(decimal valor, string obs)
		{
			int ret = ACBrDll.ECF_Sangria(this.Handle, (double)valor, ToUTF8(obs));
			CheckResult(ret);
		}

		#endregion Suprimento e Sangria

		#region Gaveta

		public void AbreGaveta()
		{
			int ret = ACBrDll.ECF_AbreGaveta(this.Handle);
			CheckResult(ret);
		}

		#endregion Gaveta

		#region Programação

		public void IdentificaPAF(string nomeVersao, string md5)
		{
			int ret = ACBrDll.ECF_IdentificaPAF(this.Handle, ToUTF8(nomeVersao), ToUTF8(md5));
			CheckResult(ret);
		}

		#endregion Programação

		#region AAC

		public ACBrAAC AAC
		{
			get
			{
				return this.aac;
			}
			set
			{
				if (value == null)
				{
					int ret = ACBrDll.ECF_SetAAC(this.Handle, IntPtr.Zero);
					CheckResult(ret);

					this.aac = null;
				}
				else
				{
					int ret = ACBrDll.ECF_SetAAC(this.Handle, value.Handle);
					CheckResult(ret);

					this.aac = value;
				}
			}
		}

		#endregion AAC

		#region Override Methods

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					string error = GetString(ACBrDll.ECF_GetUltimoErro);
					throw new ACBrECFException(error);

				case -2:

					throw new ACBrECFException("ACBr ECF não inicializado.");
			}
		}

		protected override void OnDisposing()
		{
			if (this.Handle != IntPtr.Zero)
			{
				Destroy(ACBrDll.ECF_Destroy);
			}
		}

		#endregion Override Methods

		#endregion Methods
	}
}