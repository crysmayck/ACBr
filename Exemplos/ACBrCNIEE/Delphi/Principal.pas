﻿unit Principal;

interface

uses
  httpsend,

  Windows, Forms, Classes, Controls, StdCtrls, ExtCtrls, Dialogs, Buttons,
  DB, Grids, DBGrids, DBCtrls, DBClient, ACBrCNIEE, ACBrBase, ACBrSocket;

type
  TfrPrincipal = class(TForm)
    btExportar: TBitBtn;
    btListar: TBitBtn;
    btProxy: TBitBtn;
    btSair: TBitBtn;
    dtsCadastro: TDataSource;
    DBGrid1: TDBGrid;
    DBNavigator1: TDBNavigator;
    GroupBox1: TGroupBox;
    OpenDialog1: TOpenDialog;
    Panel1: TPanel;
    SaveDialog1: TSaveDialog;
    Label1: TLabel;
    sbArquivo: TSpeedButton;
    Label2: TLabel;
    edArquivo: TEdit;
    edURLDownload: TEdit;
    btAbrir: TBitBtn;
    btDownload: TBitBtn;
    tmpCadastro: TClientDataSet;
    tmpCadastroMarca: TStringField;
    tmpCadastroModelo: TStringField;
    tmpCadastroVersao: TStringField;
    tmpCadastroTipo: TStringField;
    tmpCadastroMarcaDescr: TStringField;
    tmpCadastroModeloDescr: TStringField;
    tmpCadastroVersaoSB: TStringField;
    tmpCadastroQtLacreSL: TIntegerField;
    tmpCadastroQTLacreFab: TIntegerField;
    tmpCadastroMFD: TStringField;
    tmpCadastroLacreMFD: TStringField;
    tmpCadastroAtoAprovacao: TStringField;
    tmpCadastroAtoRegistroMG: TStringField;
    tmpCadastroFormatoNumero: TStringField;
    ACBrCNIEE1: TACBrCNIEE;
    procedure btAbrirClick(Sender: TObject);
    procedure btDownloadClick(Sender: TObject);
    procedure btExportarClick(Sender: TObject);
    procedure btListarClick(Sender: TObject);
    procedure btProxyClick(Sender: TObject);
    procedure btSairClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure sbArquivoClick(Sender: TObject);
  private
    { private declarations }
  public
    { public declarations }
  end;

var
    frPrincipal: TfrPrincipal;

implementation

uses
  ProxyConfig, WinInet, SysUtils, ACBrUtil;

{$R *.dfm}

{ TfrPrincipal }

procedure TfrPrincipal.FormCreate(Sender: TObject);
begin
  edArquivo.Text := ExtractFilePath(Application.ExeName) + 'Tabela_CNIEE.bin';
  ACBrCNIEE1.Arquivo := edArquivo.Text;
end;

procedure TfrPrincipal.FormShow(Sender: TObject);
begin
  if FilesExists(edArquivo.Text) then
    btAbrir.Click;
end;

procedure TfrPrincipal.sbArquivoClick(Sender: TObject);
begin
  if OpenDialog1.Execute then
  begin
    edArquivo.Text := OpenDialog1.FileName;
    btAbrir.Click;
  end;
end;

procedure TfrPrincipal.btDownloadClick(Sender: TObject);
begin
  tmpCadastro.Close;

  ACBrCNIEE1.URLDownload := edURLDownload.Text;
  if ACBrCNIEE1.DownloadTabela then
  begin
    MessageDlg('Download da tabela efetuado com sucesso.', mtInformation, [mbOK], 0);

    if MessageDlg('Deseja abrir a tabela e mostrar os dados?', mtInformation, mbYesNo, 0) = mrYes then
      btAbrir.Click;
  end
  else
    MessageDlg('Não foi possível efetuar o download da tabela.', mtError, [mbOK], 0);
end;

procedure TfrPrincipal.btAbrirClick(Sender: TObject);
var
  I: Integer;
begin
  ACBrCNIEE1.Arquivo := edArquivo.Text;
  if ACBrCNIEE1.AbrirTabela then
  begin
    tmpCadastro.Close;
    tmpCadastro.CreateDataSet;
    tmpCadastro.DisableControls;
    try
      for I := 0 to ACBrCNIEE1.Cadastros.Count - 1 do
      begin
        tmpCadastro.Append;
        tmpCadastroMarca.AsString         := ACBrCNIEE1.Cadastros[I].CodMarca;
        tmpCadastroModelo.AsString        := ACBrCNIEE1.Cadastros[I].CodCodModelo;
        tmpCadastroVersao.AsString        := ACBrCNIEE1.Cadastros[I].CodCodVersao;
        tmpCadastroTipo.AsString          := ACBrCNIEE1.Cadastros[I].TipoECF;
        tmpCadastroMarcaDescr.AsString    := ACBrCNIEE1.Cadastros[I].DescrMarca;
        tmpCadastroModeloDescr.AsString   := ACBrCNIEE1.Cadastros[I].DescrModelo;
        tmpCadastroVersaoSB.AsString      := ACBrCNIEE1.Cadastros[I].Versao;
        tmpCadastroQtLacreSL.AsInteger    := ACBrCNIEE1.Cadastros[I].QtLacresSL;
        tmpCadastroQtLacreFab.AsInteger   := ACBrCNIEE1.Cadastros[I].QtLacresFab;
        tmpCadastroMFD.AsString           := ACBrCNIEE1.Cadastros[I].TemMFD;
        tmpCadastroLacreMFD.AsString      := ACBrCNIEE1.Cadastros[I].TemLacreMFD;
        tmpCadastroAtoAprovacao.AsString  := ACBrCNIEE1.Cadastros[I].AtoAprovacao;
        tmpCadastroAtoRegistroMG.AsString := ACBrCNIEE1.Cadastros[I].AtoRegistro;
        tmpCadastroFormatoNumero.AsString := ACBrCNIEE1.Cadastros[I].FormatoNumFabricacao;
        tmpCadastro.Post;
      end;
    finally
      tmpCadastro.First;
      tmpCadastro.EnableControls;
    end;

    MessageDlg('Tabela aberta com sucesso.', mtInformation, [mbOK], 0);
  end;
end;

procedure TfrPrincipal.btProxyClick(Sender: TObject);
Var
  frProxyConfig: TfrProxyConfig;
begin
  frProxyConfig := TfrProxyConfig.Create(self);
  try
    frProxyConfig.edServidor.Text := ACBrCNIEE1.ProxyHost;
    frProxyConfig.edPorta.Text    := ACBrCNIEE1.ProxyPort;
    frProxyConfig.edUser.Text     := ACBrCNIEE1.ProxyUser;
    frProxyConfig.edSenha.Text    := ACBrCNIEE1.ProxyPass;

    if frProxyConfig.ShowModal = mrOK then
    begin
      ACBrCNIEE1.ProxyHost := frProxyConfig.edServidor.Text;
      ACBrCNIEE1.ProxyPort := frProxyConfig.edPorta.Text;
      ACBrCNIEE1.ProxyUser := frProxyConfig.edUser.Text;
      ACBrCNIEE1.ProxyPass := frProxyConfig.edSenha.Text;
    end;
  finally
    frProxyConfig.Free;
  end;
end;

procedure TfrPrincipal.btExportarClick(Sender: TObject);
begin
  MessageDlg('Função ainda não Implementada', mtError, [mbOK], 0);
end;

procedure TfrPrincipal.btListarClick(Sender: TObject);
begin
  MessageDlg('Função ainda não Implementada', mtError, [mbOK], 0);
end;

procedure TfrPrincipal.btSairClick(Sender: TObject);
begin
  Close;
end;

end.