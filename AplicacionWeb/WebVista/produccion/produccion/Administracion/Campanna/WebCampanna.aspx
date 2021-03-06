<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/produccion/masterPrincipal.Master" AutoEventWireup="true" CodeBehind="WebCampanna.aspx.cs" Inherits="WebVista.produccion.produccion.Administracion.Campanna.WebCampanna" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <asp:HiddenField ID="HfId" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="messagealert" id="alert_container">
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnRegistrar" />
        </Triggers>
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnActualiza" />
        </Triggers>
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnCancelar" />
        </Triggers>
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnEliminar" />
        </Triggers>
    </asp:UpdatePanel>

    <div class="right_col" role="main">
        <p>Campañas registradas</p>
        <div class="">
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="x_panel">
                        <div class="x_content">
                            <div class="form-horizontal form-label-left">
                                <div class="x_title">
                                    <h2>
                                        <label id="LblTitulo" runat="server" class="control-label col-md-0 col-sm-0 col-xs-0" for="">
                                            Campos a importar<span class="required"></span>
                                        </label>
                                    </h2>
                                    <ul class="nav navbar-right panel_toolbox">
                                        <li class="dropdown"></li>
                                    </ul>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="item form-group">
                                    <asp:Panel ID="PnCargarDatos" Visible="true" runat="server">
                                        <label class="control-label col-md-0 col-sm-0 col-xs-0" for="">
                                            Por favor seleccione un archivo<span class="required"></span>
                                        </label>
                                        <div class="item form-group">
                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                            <br />
                                            <label class="control-label col-md-0 col-sm-0 col-xs-0" for="">
                                                Los CHECKS seleccionardos son los que se va a importar<span class="required"></span>
                                            </label>
                                            <div class="col-sm-12 col-xs-12">

                                                <asp:CheckBoxList ID="CbNomre" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="1" Text="Nombre" Selected="True"> Nombre </asp:ListItem>
                                                </asp:CheckBoxList>
                                                <asp:CheckBoxList ID="CbApellido" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="2" Text="Apellido" Selected="True">Apellido</asp:ListItem>
                                                </asp:CheckBoxList>
                                                <asp:CheckBoxList ID="CbDireccion" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="3" Text="Direccion" Selected="True">Direccion</asp:ListItem>
                                                </asp:CheckBoxList>
                                                <asp:CheckBoxList ID="CbTelefono" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="4" Text="Telefono" Selected="True">Telefono</asp:ListItem>
                                                </asp:CheckBoxList>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="PnCampos" Visible="false" runat="server">
                                        <div class="item form-group">
                                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                                                Nombres<span class="required"></span>
                                            </label>
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <asp:TextBox ID="TxtNombre" runat="server" class="form-control col-md-7 col-xs-12" MaxLength="50"
                                                    ToolTip="Nombres" placeholder="Wish"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                                                Apellidos<span class="required"></span>
                                            </label>
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <asp:TextBox ID="TxtApellido" runat="server" class="form-control col-md-7 col-xs-12" MaxLength="50"
                                                    ToolTip="Apellido" placeholder="Wish"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                                                Telefono<span class="required"></span>
                                            </label>
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <asp:TextBox ID="TxtTelefono" runat="server" class="form-control col-md-7 col-xs-12" MaxLength="50"
                                                    ToolTip="Telefono " placeholder="Wish"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                                                Dirección <span class="required"></span>
                                            </label>
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <asp:TextBox ID="TxtDireccion" runat="server" class="form-control col-md-7 col-xs-12" MaxLength="50"
                                                    ToolTip="Direción" placeholder="Wish"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                                                Producto<span class="required">*</span>
                                            </label>
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <asp:TextBox ID="TxtProducto" runat="server" Enabled="false" class="form-control col-md-7 col-xs-12" MaxLength="50"
                                                    ToolTip="Producto" placeholder="Wish" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="item form-group">
                                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="">
                                                Codigo <span class="required">*</span>
                                            </label>
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <asp:TextBox ID="TxtCodigo" runat="server" Enabled="false" class="form-control col-md-7 col-xs-12" MaxLength="50"
                                                    ToolTip=" Codigo" placeholder="Wish" required="required"></asp:TextBox>
                                            </div>
                                        </div>
                                    </asp:Panel>

                                    <%--<div class="ln_solid"></div>--%>
                                </div>
                                <div class="ln_solid"></div>
                                <div class="form-group">
                                    <div class="col-md-6 col-md-offset-3">
                                        <!--Campo botoneras-->
                                        <asp:Button ID="BtnRegistrar" runat="server" Text="REGISTRAR" Visible="true" ToolTip="Botón para realizar un registro" CssClass="btn btn-primary" ValidationGroup="GUARDAR" OnClick="BtnRegistrar_Click" />
                                        <asp:Button ID="BtnActualiza" runat="server" Text="ACTIALIZAR" Visible="false" ToolTip="Botón para actualizar un registro" CssClass="btn btn-success" ValidationGroup="GUARDAR" OnClick="BtnActualiza_Click" />
                                        <asp:Button ID="BtnCancelar" runat="server" Text="CANCELAR" Visible="true" ToolTip="Botón para cancelar todo tipo de proceso" CssClass="btn btn-danger" OnClick="BtnCancelar_Click" />
                                        <asp:Button ID="BtnEliminar" runat="server" Text="ELIMINAR" Visible="false" ToolTip="botón para eliminar un registro seleccionado" CssClass="btn btn-dark" OnClick="BtnEliminar_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
            <div class="x_panel">
                <div class="row">

                    <div class="x_title">
                        <h2>Lista de Autores registrados <small></small></h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="table-responsive">
                        <table id="datatable" class="table table-striped table-bordered dt-responsive nowrap">

                            <asp:GridView ID="GvDatos" runat="server" Height="14px" Width="991px" Style="text-transform: uppercase"
                                EmptyDataText=""
                                HorizontalAlign="Center"
                                CellPadding="10"
                                CssClass="table table-striped table-bordered table-hover dataTable"
                                Font-Size="X-Small" ForeColor="Black" GridLines="Vertical"
                                PageSize="10" ShowFooter="True" ShowHeaderWhenEmpty="True"
                                ViewStateMode="Enabled" UseAccessibleHeader="False"
                                AutoGenerateColumns="False"
                                DataKeyNames="CAMPANNASID,CAMPANNASNOMBRE,CAMPANNASAPELLIDOS,CAMPANNASTELEFONO,CAMPANNASDIRECCION,CAMPANNAPRODUCTO,CAMPANNACODIGO"
                                OnSelectedIndexChanged="GvDatos_SelectedIndexChanged"
                                OnPageIndexChanging="GvDatos_PageIndexChanging1" OnPageIndexChanged="GvDatos_PageIndexChanging">
                                <AlternatingRowStyle BackColor="White" ForeColor="Black" Height="12px"
                                    Wrap="True" />
                                <Columns>
                                    <asp:CommandField ButtonType="Image" HeaderText="SELECT"
                                        SelectImageUrl="~/produccion/images/edit.png" ShowSelectButton="True">
                                        <ItemStyle Width="25px" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="CAMPANNASID" HeaderText="CAMPANNASID"
                                        Visible="false" />
                                    <asp:BoundField DataField="CAMPANNASNOMBRE" HeaderText="Nombres">
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CAMPANNASAPELLIDOS" HeaderText="Apellidos">
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CAMPANNASTELEFONO" HeaderText="Telefono">
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CAMPANNASDIRECCION" HeaderText="Direccion">
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CAMPANNAPRODUCTO" HeaderText="Producto">
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CAMPANNACODIGO" HeaderText="Codigo">
                                        <FooterStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                </Columns>
                                <EditRowStyle BackColor="White" />
                                <FooterStyle BackColor="#006699" Font-Bold="True" ForeColor="White"
                                    HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"
                                    Height="10px" HorizontalAlign="Center" VerticalAlign="Top" Width="10px"
                                    Wrap="False" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="Black" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
