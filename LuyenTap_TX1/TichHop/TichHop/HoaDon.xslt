<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" 
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	exclude-result-prefixes="ns"
	xmlns:ns="http://tempuri.org/HoaDon.xsd"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
		<html>
			<head>
				<title>Phiếu mua hàng</title>
				<style>
					.container{
						width: 500px;
						border: 1px solid black;
						margin: 0 auto;
						padding: 16px;
						margin-bottom: 32px;
					}
					h1{
						color: pink;
						text-transform: uppercase;
						font-weight: bold;
					}

				</style>
			</head>
			<body>
				<h1>Phiếu mua hàng</h1>
				<br></br>
				<xsl:for-each select="ns:DS/ns:HoaDon">
				<div class="container">
					<table>
						<tr>
							<td>
								<b>Hóa đơn: </b>
								<xsl:value-of select="ns:MaHD"/> </td>
							<td>
								<b>Ngày bán: </b>
								<xsl:value-of select="ns:NgayBan"/>
							</td>
						</tr>
						<tr>
							<td>
								<b>Loại hàng: <xsl:value-of select="ns:LoaiHang/@TenLoai"/>
							</b>
							</td>
						</tr>
					</table>
					<table border="1" cellspacing="1" width="450px">
						<tr>
							<th>Mã hàng</th>
							<th>Tên hàng</th>
							<th>Số lượng</th>
							<th>Đơn giá</th>
							<th>Thành tiền</th>
						</tr>
						<xsl:for-each select="ns:LoaiHang/ns:Hang">
							<xsl:sort select="ns:DonGia" data-type="number" order="descending"/>
							<tr>
								<td>
									<xsl:value-of select="@MaHang"/>
								</td>
								<td>
									<xsl:value-of select="ns:TenHang"/>
								</td>
								<td>
									<xsl:value-of select="ns:SoLuong"/>
								</td>
								<td>
									<xsl:value-of select="ns:DonGia"/>
								</td>
								<td>
									<xsl:value-of select="ns:DonGia * ns:SoLuong"/>
								</td>
							</tr>
						</xsl:for-each>
					</table>
				</div>
				</xsl:for-each>
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>
