{******************************************************************************}
{ Projeto: Componentes ACBr                                                    }
{  Biblioteca multiplataforma de componentes Delphi para intera��o com equipa- }
{ mentos de Automa��o Comercial utilizados no Brasil                           }
{                                                                              }
{ Direitos Autorais Reservados (c) 2009   Isaque Pinheiro                      }
{                                                                              }
{ Colaboradores nesse arquivo:                                                 }
{                                                                              }
{  Voc� pode obter a �ltima vers�o desse arquivo na pagina do  Projeto ACBr    }
{ Componentes localizado em      http://www.sourceforge.net/projects/acbr      }
{                                                                              }
{  Esta biblioteca � software livre; voc� pode redistribu�-la e/ou modific�-la }
{ sob os termos da Licen�a P�blica Geral Menor do GNU conforme publicada pela  }
{ Free Software Foundation; tanto a vers�o 2.1 da Licen�a, ou (a seu crit�rio) }
{ qualquer vers�o posterior.                                                   }
{                                                                              }
{  Esta biblioteca � distribu�da na expectativa de que seja �til, por�m, SEM   }
{ NENHUMA GARANTIA; nem mesmo a garantia impl�cita de COMERCIABILIDADE OU      }
{ ADEQUA��O A UMA FINALIDADE ESPEC�FICA. Consulte a Licen�a P�blica Geral Menor}
{ do GNU para mais detalhes. (Arquivo LICEN�A.TXT ou LICENSE.TXT)              }
{                                                                              }
{  Voc� deve ter recebido uma c�pia da Licen�a P�blica Geral Menor do GNU junto}
{ com esta biblioteca; se n�o, escreva para a Free Software Foundation, Inc.,  }
{ no endere�o 59 Temple Street, Suite 330, Boston, MA 02111-1307 USA.          }
{ Voc� tamb�m pode obter uma copia da licen�a em:                              }
{ http://www.opensource.org/licenses/lgpl-license.php                          }
{                                                                              }
{ Daniel Sim�es de Almeida  -  daniel@djsystem.com.br  -  www.djsystem.com.br  }
{              Pra�a Anita Costa, 34 - Tatu� - SP - 18270-410                  }
{                                                                              }
{******************************************************************************}

{******************************************************************************
|* Historico
|*
|* 10/04/2009: Isaque Pinheiro
|*  - Cria��o e distribui��o da Primeira Versao
*******************************************************************************}

unit ACBrECDBloco_0_Class;

interface

uses SysUtils, Classes, DateUtils, ACBrSped, ACBrECDBloco_0;

type
  /// TBLOCO_0 - Abertura, Identifica��o e Refer�ncias
  TBloco_0 = class(TACBrSPED)
  private
    FRegistro0000: TRegistro0000;      /// BLOCO 0 - Registro0000
    FRegistro0001: TRegistro0001;      /// BLOCO 0 - Registro0001
    FRegistro0007: TRegistro0007List;  /// BLOCO 0 - Lista de Registro0007
    FRegistro0020: TRegistro0020List;  /// BLOCO 0 - Lista de Registro0020
    FRegistro0150: TRegistro0150List;  /// BLOCO 0 - Lista de Registro0150
    FRegistro0180: TRegistro0180List;  /// BLOCO 0 - Lista de Registro0180
    FRegistro0990: TRegistro0990;      /// BLOCO 0 - Registro0990
  protected
  public
    constructor Create(AOwner: TComponent); override; /// Create
    destructor Destroy; override; /// Destroy
    procedure LimpaRegistros;

    function WriteRegistro0000: AnsiString;
    function WriteRegistro0001: AnsiString;
    function WriteRegistro0007: AnsiString;
    function WriteRegistro0020: AnsiString;
    function WriteRegistro0150: AnsiString;
    function WriteRegistro0180: AnsiString;
    function WriteRegistro0990: AnsiString;

    property Registro0000: TRegistro0000     read FRegistro0000 write FRegistro0000;
    property Registro0001: TRegistro0001     read FRegistro0001 write FRegistro0001;
    property Registro0007: TRegistro0007List read FRegistro0007 write FRegistro0007;
    property Registro0020: TRegistro0020List read FRegistro0020 write FRegistro0020;
    property Registro0150: TRegistro0150List read FRegistro0150 write FRegistro0150;
    property Registro0180: TRegistro0180List read FRegistro0180 write FRegistro0180;
    property Registro0990: TRegistro0990 read FRegistro0990 write FRegistro0990;
  end;

implementation

uses ACBrSpedUtils;

{ TBloco_0 }

constructor TBloco_0.Create(AOwner: TComponent);
begin
  inherited Create(AOwner);
  FRegistro0000 := TRegistro0000.Create;
  FRegistro0001 := TRegistro0001.Create;
  FRegistro0007 := TRegistro0007List.Create;
  FRegistro0020 := TRegistro0020List.Create;
  FRegistro0150 := TRegistro0150List.Create;
  FRegistro0180 := TRegistro0180List.Create;
  FRegistro0990 := TRegistro0990.Create;

  FRegistro0990.QTD_LIN_0 := 0;
end;

destructor TBloco_0.Destroy;
begin
  FRegistro0000.Free;
  FRegistro0001.Free;
  FRegistro0007.Free;
  FRegistro0020.Free;
  FRegistro0150.Free;
  FRegistro0180.Free;
  FRegistro0990.Free;
  inherited;
end;

procedure TBloco_0.LimpaRegistros;
begin
  FRegistro0007.Clear;
  FRegistro0020.Clear;
  FRegistro0150.Clear;
  FRegistro0180.Clear;

  FRegistro0990.QTD_LIN_0 := 0;
end;

function TBloco_0.WriteRegistro0000: AnsiString;
begin
  Result := '';

  if Assigned(Registro0000) then
  begin
     with Registro0000 do
     begin
       Check(funChecaCNPJ(CNPJ), '(0-0000) ENTIDADE: O CNPJ "%s" digitado � inv�lido!', [CNPJ]);
       Check(funChecaUF(UF), '(0-0000) ENTIDADE: A UF "%s" digitada � inv�lido!', [UF]);
       Check(funChecaIE(IE, UF), '(0-0000) ENTIDADE: A inscri��o estadual "%s" digitada � inv�lida!', [IE]);
       Check(funChecaMUN(StrToInt(COD_MUN)), '(0-0000) ENTIDADE: O c�digo do munic�pio "%s" digitado � inv�lido!', [COD_MUN]);
       Check(((IND_SIT_ESP >= '0') and (IND_SIT_ESP <= '4')), '(0-0000) ENTIDADE: O indicador "%s" de situa��o especial, deve ser informado o n�mero 0 ou 1 ou 2 ou 3 ou 4!', [IND_SIT_ESP]);
       ///
       Result := LFill('0000') +
                 LFill('LECD') +
                 LFill(DT_INI) +
                 LFill(DT_FIN) +
                 LFill(NOME) +
                 LFill(CNPJ) +
                 LFill(UF) +
                 LFill(IE) +
                 LFill(COD_MUN, 7) +
                 LFill(IM) +
                 LFill(IND_SIT_ESP, 1) +
                 Delimitador +
                 #13#10;
       ///
       Registro0990.QTD_LIN_0 := Registro0990.QTD_LIN_0 + 1;
     end;
  end;
end;

function TBloco_0.WriteRegistro0001: AnsiString;
begin
  Result := '';

  if Assigned(Registro0001) then
  begin
     with Registro0001 do
     begin
       Check(((IND_DAD = 0) or (IND_DAD = 1)), '(0-0001) ABERTURA DO BLOCO: Na abertura do bloco, deve ser informado o n�mero 0 ou 1!');
       ///
       Result := LFill('0001') +
                 LFill(IND_DAD, 0) +
                 Delimitador +
                 #13#10;
       ///
       Registro0990.QTD_LIN_0 := Registro0990.QTD_LIN_0 + 1;
     end;
  end;
end;

function TBloco_0.WriteRegistro0007: AnsiString;
var
intFor: integer;
strRegistro0007: AnsiString;
begin
  strRegistro0007 := '';

  if Assigned(Registro0007) then
  begin
     for intFor := 0 to Registro0007.Count - 1 do
     begin
        with Registro0007.Items[intFor] do
        begin
           ///
           strRegistro0007 :=  strRegistro0007 + LFill('0007') +
                                                 LFill(COD_ENT_REF) +
                                                 LFill(COD_INSCR) +
                                                 Delimitador +
                                                 #13#10;
        end;
        Registro0990.QTD_LIN_0 := Registro0990.QTD_LIN_0 + 1;
     end;
  end;
  Result := strRegistro0007;
end;

function TBloco_0.WriteRegistro0020: AnsiString;
var
intFor: integer;
strRegistro0020: AnsiString;
begin
  strRegistro0020 := '';

  if Assigned(Registro0020) then
  begin
     for intFor := 0 to Registro0020.Count - 1 do
     begin
        with Registro0020.Items[intFor] do
        begin
           Check(((IND_DEC = 0) or (IND_DEC = 1)), '(0-0020) ENTIDADE: O Indicador de descentraliza��o, deve ser informado o n�mero 0 ou 1!');
           Check(funChecaCNPJ(CNPJ), '(0-0020) ENTIDADE: O CNPJ "%s" digitado � inv�lido!', [CNPJ]);
           Check(funChecaUF(UF), '(0-0020) ENTIDADE: A UF "%s" digitada � inv�lido!', [UF]);
           Check(funChecaIE(IE, UF), '(0-0020) ENTIDADE: A inscri��o estadual "%s" digitada � inv�lida!', [IE]);
           Check(funChecaMUN(StrToInt(COD_MUN)), '(0-0020) ENTIDADE: O c�digo do munic�pio "%s" digitado � inv�lido!', [COD_MUN]);
           ///
           strRegistro0020 :=  strRegistro0020 + LFill('0020') +
                                                 LFill(IND_DEC) +
                                                 LFill(CNPJ) +
                                                 LFill(UF) +
                                                 LFill(IE) +
                                                 LFill(COD_MUN) +
                                                 LFill(IM) +
                                                 LFill(NIRE) +
                                                 Delimitador +
                                                 #13#10;
        end;
        Registro0990.QTD_LIN_0 := Registro0990.QTD_LIN_0 + 1;
     end;
  end;
  Result := strRegistro0020;
end;

function TBloco_0.WriteRegistro0150: AnsiString;
var
intFor: integer;
strRegistro0150: AnsiString;
begin
  strRegistro0150 := '';

  if Assigned(Registro0150) then
  begin
     for intFor := 0 to Registro0150.Count - 1 do
     begin
        with Registro0150.Items[intFor] do
        begin
           Check(funChecaPAISIBGE(COD_PAIS), '(0-0150) %s-%s, o c�digo do pa�s "%s" digitado � inv�lido!', [COD_PART, NOME, COD_PAIS]);
           if Length(CNPJ) > 0 then
              Check(funChecaCNPJ(CNPJ), '(0-0150) %s-%s, o CNPJ "%s" digitado � inv�lido!', [COD_PART, NOME, CNPJ]);
           if Length(CPF)  > 0 then
              Check(funChecaCPF(CPF), '(0-0150) %s-%s, o CPF "%s" digitado � inv�lido!', [COD_PART, NOME, CPF]);
//           Check(funChecaIE(IE, UF),         '(0-0150) %s-%s, a Inscri��o Estadual "%s" digitada � inv�lida!', [COD_PART, NOME, IE]);
           Check(funChecaMUN(COD_MUN),       '(0-0150) %s-%s, o c�digo do munic�pio "%s" digitado � inv�lido!', [COD_PART, NOME, IntToStr(COD_MUN)]);
           Check(NOME <> '',                 '(0-0150) O nome do participante � obrigat�rio!');
           ///
           strRegistro0150 :=  strRegistro0150 + LFill('0150') +
                                                 LFill(COD_PART) +
                                                 LFill(NOME) +
                                                 LFill(COD_PAIS) +
                                                 LFill(CNPJ) +
                                                 LFill(CPF) +
                                                 LFill(NIT) +
                                                 LFill(UF) +
                                                 LFill(IE) +
                                                 LFill(IE_ST) +
                                                 LFill(COD_MUN, 7) +
                                                 LFill(IM) +
                                                 LFill(SUFRAMA) +
                                                 Delimitador +
                                                 #13#10;
        end;
        Registro0990.QTD_LIN_0 := Registro0990.QTD_LIN_0 + 1;
     end;
  end;
  Result := strRegistro0150;
end;

function TBloco_0.WriteRegistro0180: AnsiString;
var
intFor: integer;
strRegistro0180: AnsiString;
begin
  strRegistro0180 := '';

  if Assigned(Registro0180) then
  begin
     for intFor := 0 to Registro0180.Count - 1 do
     begin
        with Registro0180.Items[intFor] do
        begin
           Check(((COD_REL >= '01') and (COD_REL <= '11')), '(0-0180) ENTIDADE: O c�digo "%s" de relacionamento, deve ser informado o n�mero na faixa de 01 at� 11!', [COD_REL]);
           ///
           strRegistro0180 :=  strRegistro0180 + LFill('0180') +
                                                 LFill(COD_REL) +
                                                 LFill(DT_INI_REL) +
                                                 LFill(DT_FIN_REL) +
                                                 Delimitador +
                                                 #13#10;
        end;
        Registro0990.QTD_LIN_0 := Registro0990.QTD_LIN_0 + 1;
     end;
  end;
  Result := strRegistro0180;
end;

function TBloco_0.WriteRegistro0990: AnsiString;
begin
  Result := '';

  if Assigned(Registro0990) then
  begin
     with Registro0990 do
     begin
       QTD_LIN_0 := QTD_LIN_0 + 1;
       ///
       Result := LFill('0990') +
                 LFill(QTD_LIN_0,0) +
                 Delimitador +
                 #13#10;
     end;
  end;
end;

end.
